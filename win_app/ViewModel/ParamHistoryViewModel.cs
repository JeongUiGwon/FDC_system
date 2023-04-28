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
    public class ParamHistoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ParamHistoryModel> _paramHistory;

        public ParamHistoryViewModel()
        {
            SetParamHistory();
        }

        public ObservableCollection<ParamHistoryModel> ParamHistory
        {
            get { return _paramHistory; }
            set
            {
                _paramHistory = value;
                OnPropertyChanged(nameof(ParamHistory));
            }
        }

        private async void SetParamHistory()
        {
            HttpResponseMessage response = await GetParamHistory.GetParamHistoryAsync();
            ObservableCollection<ParamHistoryModel> content = new ObservableCollection<ParamHistoryModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamHistoryModel>>(str_content);
                ParamHistory = new ObservableCollection<ParamHistoryModel>(content);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
