using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using Newtonsoft.Json;
using SOM.Model;
using SOM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SOM.ViewModel
{
    public class DataViewModel : INotifyPropertyChanged
    {
        public DataViewModel()
        {
            SetEquipments();
            ApplyCommand = new RelayCommand(ExecuteApplyCommand);

            // 조회시간 초기값 세팅
            StartDate = DateTime.Now.AddMonths(-3).ToString("yyyy-MM-dd");
            StartTime = DateTime.Now.ToString("HH:mm");
            EndtDate = DateTime.Today.ToString("yyyy-MM-dd");
            EndTime = DateTime.Now.ToString("HH:mm");
        }

        private ObservableCollection<EquipmentsModel> _equipments;
        public ObservableCollection<EquipmentsModel> Equipments
        {
            get { return _equipments; }
            set
            {
                _equipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }

        private ObservableCollection<EquipmentsModel> _filteredEquipments;
        public ObservableCollection<EquipmentsModel> FilteredEquipments
        {
            get { return _filteredEquipments; }
            set
            {
                _filteredEquipments = value;
                OnPropertyChanged(nameof(FilteredEquipments));
            }
        }

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
                FilterEquipments();
            }
        }

        private bool _isAllSelected;
        public bool IsAllSelected
        {
            get { return _isAllSelected; }
            set
            {
                _isAllSelected = value;
                OnPropertyChanged(nameof(IsAllSelected));
                SelectAllEquipments();
                FilterEquipments();
            }
        }

        private string _startDate;
        public string StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private string _endDate;
        public string EndtDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndtDate));
            }
        }

        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set
            {
                _endTime = value;
                OnPropertyChanged(nameof(EndTime));
            }
        }

        private string _paramList;
        public string ParamList
        {
            get { return _paramList; }
            set
            {
                _paramList = value;
                OnPropertyChanged(nameof(ParamList));
            }
        }

        private ObservableCollection<ParamLogModel> _equipmentData;
        public ObservableCollection<ParamLogModel> EquipmentData
        {
            get { return _equipmentData; }
            set
            {
                _equipmentData = value;
                OnPropertyChanged(nameof(EquipmentData));
            }
        }
        public ICommand ApplyCommand { get; }

        private ObservableCollection<CartesianChartModel> _chartSeriesCollection;
        public ObservableCollection<CartesianChartModel> ChartSeriesCollection
        {
            get { return _chartSeriesCollection; }
            set
            {
                _chartSeriesCollection = value;
                OnPropertyChanged(nameof(ChartSeriesCollection));
            }
        }

        private async void SetEquipments()
        {
            HttpResponseMessage response = await GetEquipment.GetEquipmentAsync();
            ObservableCollection<EquipmentsModel> content = new ObservableCollection<EquipmentsModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<EquipmentsModel>>(str_content);
                Equipments = new ObservableCollection<EquipmentsModel>(content);
                FilterEquipments();
            }
        }

        private void FilterEquipments()
        {
            if (Equipments != null && Equipments.Any() && !string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredEquipments = new ObservableCollection<EquipmentsModel>(Equipments.Where(e => e.equipment_id.Contains(SearchTerm)
                || e.equipment_name.Contains(SearchTerm) || e.interlock_id.Contains(SearchTerm) || e.creator_name.Contains(SearchTerm)));
            }
            else
            {
                FilteredEquipments = Equipments;
            }
        }

        private void SelectAllEquipments()
        {
            foreach (EquipmentsModel equipment in Equipments)
            {
                equipment.isSelected = IsAllSelected;
            }
        }

        private async void ExecuteApplyCommand()
        {
            var selectedEquipments = FilteredEquipments.Where(el => el.isSelected).ToList();

            string str_selectedEquipments = string.Join(",", selectedEquipments.Select(el => el.equipment_id));

            string startDate = $"{StartDate} {StartTime}";
            string endDate = $"{EndtDate}   {EndTime}";

            string str_params = ParamList;

            HttpResponseMessage response_getParamLog = await GetParamLog.GetParamLogAsync(str_selectedEquipments, str_params, startDate, endDate);
            ObservableCollection<ParamLogModel> content = new ObservableCollection<ParamLogModel>();

            // 설비 데이터를 DataGrid에 바인딩
            if (response_getParamLog != null && response_getParamLog.Content != null)
            {
                string str_content = await response_getParamLog.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamLogModel>>(str_content);
                EquipmentData = new ObservableCollection<ParamLogModel>(content);
            }

            // 설비 데이터를 param_id에 따라 분류
            Dictionary<string, List<ParamLogModel>> paramData = new Dictionary<string, List<ParamLogModel>>();

            foreach (ParamLogModel equipmentData_item in content)
            {
                if (paramData.ContainsKey($"{equipmentData_item.param_name}\t{equipmentData_item.equipment_name}"))
                {
                    paramData[$"{equipmentData_item.param_name}\t{equipmentData_item.equipment_name}"].Add(equipmentData_item);
                }
                else
                {
                    paramData[$"{equipmentData_item.param_name}\t{equipmentData_item.equipment_name}"] = new List<ParamLogModel> { equipmentData_item };
                }
            }

            // 차트 컬렉션 초기화
            ChartSeriesCollection = new ObservableCollection<CartesianChartModel>();

            // 차트 생성
            foreach (var kvp in paramData)
            {
                string title = kvp.Key;
                List<ParamLogModel> paramLogs = kvp.Value;
                ChartValues<float> ChartData = new ChartValues<float>();
                List<string> ChartLabels = new List<string>();

                foreach (var paramLog in paramLogs)
                {
                    long timestamp = new DateTimeOffset(paramLog.created_at.ToUniversalTime()).ToUnixTimeSeconds();
                    ChartData.Add(paramLog.param_value);
                    ChartLabels.Add(paramLog.created_at.ToString());
                }

                SeriesCollection ChartSeries = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = title,
                        Values = ChartData
                    }
                };

                ChartSeriesCollection.Add(new CartesianChartModel(title, ChartSeries, ChartLabels));
            }
            
                Console.WriteLine("hello");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}