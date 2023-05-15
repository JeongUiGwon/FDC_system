using SOM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.ViewModel
{
    public class InterlockDetailViewModel : INotifyPropertyChanged
    {
        public InterlockDetailViewModel() 
        {

        }

        private InterlockLogModel _interlockData;
        public InterlockLogModel InterlockData
        {
            get { return _interlockData; }
            set
            {
                _interlockData = value;
                OnPropertyChanged(nameof(InterlockData));
            }
        }

        private CartesianChartModel _chartSeriesCollection;
        public CartesianChartModel ChartSeriesCollection
        {
            get { return _chartSeriesCollection; }
            set
            {
                _chartSeriesCollection = value;
                OnPropertyChanged(nameof(ChartSeriesCollection));
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
