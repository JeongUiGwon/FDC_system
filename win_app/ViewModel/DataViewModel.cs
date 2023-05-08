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
        public ICommand ApplyCommand { get; }

        private SeriesCollection _chartSeries;
        private ChartValues<ObservablePoint> _chartData;
        private ObservableCollection<string> _chartLabels;

        public SeriesCollection ChartSeries
        {
            get { return _chartSeries; }
            set { _chartSeries = value; OnPropertyChanged(); }
        }

        public ChartValues<ObservablePoint> ChartData
        {
            get { return _chartData; }
            set { _chartData = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> ChartLabels
        {
            get { return _chartLabels; }
            set { _chartLabels = value; OnPropertyChanged(); }
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

        private void ExecuteApplyCommand()
        {
            Console.WriteLine("hello");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}