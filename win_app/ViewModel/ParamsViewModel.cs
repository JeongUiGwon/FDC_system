using Newtonsoft.Json;
using SOM.Model;
using SOM.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;

namespace SOM.ViewModel
{
    public class ParamsViewModel : INotifyPropertyChanged
    {

        public ParamsViewModel()
        {
            SetParams();
        }

        private ObservableCollection<ParamsModel> _params;
        public ObservableCollection<ParamsModel> Params
        {
            get { return _params; }
            set
            {
                _params = value;
                OnPropertyChanged(nameof(Params));
            }
        }

        private ObservableCollection<ParamsModel> _filteredParams;
        public ObservableCollection<ParamsModel> FilteredParams
        {
            get { return _filteredParams; }
            set
            {
                _filteredParams = value;
                OnPropertyChanged(nameof(FilteredParams));
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
                FilterParams();
            }
        }

        private async void SetParams()
        {
            HttpResponseMessage response = await GetParams.GetParamsAsync();
            ObservableCollection<ParamsModel> content = new ObservableCollection<ParamsModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamsModel>>(str_content);
                Params = new ObservableCollection<ParamsModel>(content);
                FilterParams();
            }
        }

        private void FilterParams()
        {
            if (Params != null && Params.Any() && !string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredParams = new ObservableCollection<ParamsModel>(Params.Where(e => e.param_id.Contains(SearchTerm) || e.param_name.Contains(SearchTerm)
                || e.param_level.Contains(SearchTerm) || e.param_state.Contains(SearchTerm) || e.creator_name.Contains(SearchTerm))); ;
            }
            else
            {
                FilteredParams = Params;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
