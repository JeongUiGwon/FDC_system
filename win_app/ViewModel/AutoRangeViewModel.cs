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

namespace SOM.ViewModel
{
    public class AutoRangeViewModel : INotifyPropertyChanged
    {
        public AutoRangeViewModel()
        {

        }

        private ObservableCollection<AutoRangeModel> _autoRange;
        public ObservableCollection<AutoRangeModel> AutoRange
        {
            get { return _autoRange; }
            set
            {
                _autoRange = value;
                OnPropertyChanged(nameof(AutoRange));
            }
        }

        private ObservableCollection<AutoRangeModel> _filteredAutoRange;
        public ObservableCollection<AutoRangeModel> FilteredAutoRange
        {
            get { return _filteredAutoRange; }
            set
            {
                _filteredAutoRange = value;
                OnPropertyChanged(nameof(FilteredAutoRange));
            }
        }

        private async void SetAutoRange()
        {
            HttpResponseMessage response = await GetAutorange.GetAutorangeAsync();
            ObservableCollection<AutoRangeModel> content = new ObservableCollection<AutoRangeModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<AutoRangeModel>>(str_content);
                AutoRange = new ObservableCollection<AutoRangeModel>(content);
                //FilterEquipments();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
