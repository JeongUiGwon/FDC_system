using SOM.Model;
using SOM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.ViewModel
{
    public class EquipmentsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<EquipmentsModel> _equipments;

        public EquipmentsViewModel()
        {
            SetEquipments();
        }

        public ObservableCollection<EquipmentsModel> Equipments
        {
            get { return _equipments; }
            set
            {
                _equipments = value;
                OnPropertyChanged(nameof(Equipments));
            }
        }

        private async void SetEquipments()
        {
            ObservableCollection<EquipmentsModel> response = await GetEquipmentClass.GetEquipmentAsync();
            Equipments = new ObservableCollection<EquipmentsModel>(response);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
