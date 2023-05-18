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
        public ParamHistoryViewModel()
        {
            SetParamHistory();
        }

        private ObservableCollection<ParamHistoryModel> _paramHistory;
        public ObservableCollection<ParamHistoryModel> ParamHistory
        {
            get { return _paramHistory; }
            set
            {
                _paramHistory = value;
                OnPropertyChanged(nameof(ParamHistory));
            }
        }

        private ObservableCollection<ParamHistoryModel> _filteredParamHistory;
        public ObservableCollection<ParamHistoryModel> FilteredParamHistory
        {
            get { return _filteredParamHistory; }
            set
            {
                _filteredParamHistory = value;
                OnPropertyChanged(nameof(FilteredParamHistory));
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
                FilterParamHistory();
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
                FilterParamHistory();
            }
        }

        private void FilterParamHistory()
        {
            if (ParamHistory != null && ParamHistory.Any() && !string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredParamHistory = new ObservableCollection<ParamHistoryModel>(ParamHistory.Where(e => e.action.Contains(SearchTerm) || e.param_name.Contains(SearchTerm)
                || e.param.Contains(SearchTerm)));
            }
            else
            {
                FilteredParamHistory = ParamHistory;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
