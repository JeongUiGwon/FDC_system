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
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SOM.ViewModel
{
    public class InterlockViewModel : INotifyPropertyChanged
    {
        public InterlockViewModel()
        {
            SetEquipments();

            ApplyCommand = new RelayCommand(ExecuteApplyCommand);
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

        private string _searchEquipUse;
        public string SearchEquipUse
        {
            get { return _searchEquipUse; }
            set
            {
                _searchEquipUse = value;
                OnPropertyChanged(nameof(SearchEquipUse));
                FilterEquipments();
            }
        }

        private string _searchEquipState;
        public string SearchEquipState
        {
            get { return _searchEquipState; }
            set
            {
                _searchEquipState = value;
                OnPropertyChanged(nameof(SearchEquipState));
                FilterEquipments();
            }
        }

        private string _searchEquipMode;
        public string SearchEquipMode
        {
            get { return _searchEquipMode; }
            set
            {
                _searchEquipMode = value;
                OnPropertyChanged(nameof(SearchEquipMode));
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


        private DateTime _startDate = DateTime.Now.AddMonths(-3);
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _startTime = DateTime.Now.AddMonths(-3);
        public DateTime StartTime
        {
            get { return _startTime; }
            set
            {
                _startTime = value;
                OnPropertyChanged(nameof(StartTime));
            }
        }

        private DateTime _endDate = DateTime.Now;
        public DateTime EndtDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndtDate));
            }
        }

        private DateTime _endTime = DateTime.Now;
        public DateTime EndTime
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

        public ICommand ApplyCommand { get; private set; }

        private string _guideBoxVisibility = "Visible";
        public string GuideBoxVisibility
        {
            get { return _guideBoxVisibility; }
            set
            {
                _guideBoxVisibility = value;
                OnPropertyChanged(nameof(GuideBoxVisibility));
            }
        }

        private string _loadingVisibility = "Hidden";
        public string LoadingVisibility
        {
            get { return _loadingVisibility; }
            set
            {
                _loadingVisibility = value;
                OnPropertyChanged(nameof(LoadingVisibility));
            }
        }

        private string _btnApplyIsEnabled = "True";
        public string BtnApplyIsEnabled
        {
            get { return _btnApplyIsEnabled; }
            set
            {
                _btnApplyIsEnabled = value;
                OnPropertyChanged(nameof(BtnApplyIsEnabled));
            }
        }

        private ObservableCollection<InterlockLogModel> _interlockItemsSource;
        public ObservableCollection<InterlockLogModel> InterlockItemsSource
        {
            get { return _interlockItemsSource;}
            set
            {
                _interlockItemsSource = value;
                OnPropertyChanged(nameof(InterlockItemsSource));
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
            if (Equipments != null && Equipments.Any())
            {
                FilteredEquipments = new ObservableCollection<EquipmentsModel>(Equipments);

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    FilteredEquipments = new ObservableCollection<EquipmentsModel>(FilteredEquipments.Where(e => e.equipment_id.Contains(SearchTerm)
                    || e.equipment_name.Contains(SearchTerm) || e.interlock_id.Contains(SearchTerm)));
                }

                if (!string.IsNullOrWhiteSpace(SearchEquipUse) && SearchEquipUse != "All")
                {
                    FilteredEquipments = new ObservableCollection<EquipmentsModel>(FilteredEquipments.Where(e => e.equipment_use.Equals(SearchEquipUse)));
                }

                if (!string.IsNullOrWhiteSpace(SearchEquipState) && SearchEquipState != "All")
                {
                    FilteredEquipments = new ObservableCollection<EquipmentsModel>(FilteredEquipments.Where(e => e.equipment_state.Equals(SearchEquipState)));
                }

                if (!string.IsNullOrWhiteSpace(SearchEquipMode) && SearchEquipMode != "All")
                {
                    FilteredEquipments = new ObservableCollection<EquipmentsModel>(FilteredEquipments.Where(e => e.equipment_mode.Equals(SearchEquipMode)));
                }
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
            BtnApplyIsEnabled = "False";
            GuideBoxVisibility = "Hidden";
            LoadingVisibility = "Visible";

            var selectedEquipments = FilteredEquipments.Where(el => el.isSelected).ToList();

            string str_selectedEquipments = string.Join(",", selectedEquipments.Select(el => el.equipment_id));

            string startDate = $"{StartDate.ToString("yyyy-MM-dd")} {StartTime.ToString("HH:mm")}";
            string endDate = $"{EndtDate.ToString("yyyy-MM-dd")} {EndTime.ToString("HH:mm")}";

            string str_params = ParamList;

            HttpResponseMessage response_getInterlockLog = await GetInterlockLog.GetInterlockLogAsync(str_selectedEquipments, str_params, startDate, endDate);
            ObservableCollection<InterlockLogModel> content = new ObservableCollection<InterlockLogModel>();

            if (response_getInterlockLog != null && response_getInterlockLog.Content != null)
            {
                string str_content = await response_getInterlockLog.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<InterlockLogModel>>(str_content);
                InterlockItemsSource = content;
            }

            // 안내 문구 숨기기
            LoadingVisibility = "Hidden";
            BtnApplyIsEnabled = "True";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
