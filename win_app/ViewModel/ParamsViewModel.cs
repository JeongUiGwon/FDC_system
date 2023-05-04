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

        private ObservableCollection<ParamsModel> _selectedParams;
        public ObservableCollection<ParamsModel> SelectedParams
        {
            get { return _selectedParams; }
            set
            {
                _selectedParams = value;
                OnPropertyChanged(nameof(SelectedParams));
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

        private string _searchEquipment;
        public string SearchEquipment
        {
            get { return _searchEquipment; }
            set
            {
                _searchEquipment = value;
                OnPropertyChanged(nameof(SearchEquipment));
                FilterParams();
            }
        }

        private string _searchParamLevel;
        public string SearchParamLevel
        {
            get { return _searchParamLevel; }
            set
            {
                _searchParamLevel = value;
                OnPropertyChanged(nameof(SearchParamLevel));
                FilterParams();
            }
        }

        private string _searchParamUse;
        public string SearchParamUse
        {
            get { return _searchParamUse; }
            set
            {
                _searchParamUse = value;
                OnPropertyChanged(nameof(SearchParamUse));
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
            if (Params != null && Params.Any())
            {
                FilteredParams = new ObservableCollection<ParamsModel>(Params);

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    FilteredParams = new ObservableCollection<ParamsModel>(FilteredParams.Where(e => e.param_id.Contains(SearchTerm) || e.param_name.Contains(SearchTerm)));
                }

                if (!string.IsNullOrWhiteSpace(SearchEquipment))
                {
                    FilteredParams = new ObservableCollection<ParamsModel>(FilteredParams.Where(e => e.equipment.Contains(SearchEquipment)));
                }

                if (!string.IsNullOrWhiteSpace(SearchParamLevel) && SearchParamLevel != "All")
                {
                    FilteredParams = new ObservableCollection<ParamsModel>(FilteredParams.Where(e => e.param_level.Equals(SearchParamLevel)));
                }

                if (!string.IsNullOrWhiteSpace(SearchParamUse) && SearchParamUse != "All")
                {
                    FilteredParams = new ObservableCollection<ParamsModel>(FilteredParams.Where(e => e.param_state.Equals(SearchParamUse)));
                }

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
