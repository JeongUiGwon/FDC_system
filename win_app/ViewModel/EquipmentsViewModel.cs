using LiveCharts.Defaults;
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
using System.Threading;
using System.Threading.Tasks;
using LiveCharts.Wpf;

namespace SOM.ViewModel
{
    public class EquipmentsViewModel : INotifyPropertyChanged
    {
        public EquipmentsViewModel()
        {
            SetEquipments();
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
