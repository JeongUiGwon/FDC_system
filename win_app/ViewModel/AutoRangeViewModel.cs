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
            SetAutoRange();
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

        private string _searchTerm;
        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                OnPropertyChanged(nameof(SearchTerm));
                FilterAutoRange();
            }
        }

        private string _searchAutoRangeType;
        public string SearchAutoRangeType
        {
            get { return _searchAutoRangeType; }
            set
            {
                _searchAutoRangeType = value;
                OnPropertyChanged(nameof(SearchAutoRangeType));
                FilterAutoRange();
            }
        }

        private string _searchAutoRangeUse;
        public string SearchAutoRangeUse
        {
            get { return _searchAutoRangeUse; }
            set
            {
                _searchAutoRangeUse = value;
                OnPropertyChanged(nameof(SearchAutoRangeUse));
                FilterAutoRange();
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
                FilterAutoRange();
            }
        }

        private void FilterAutoRange()
        {
            if (AutoRange != null && AutoRange.Any())
            {
                FilteredAutoRange = new ObservableCollection<AutoRangeModel>(AutoRange);

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    FilteredAutoRange = new ObservableCollection<AutoRangeModel>(FilteredAutoRange.Where(e => e.param.Contains(SearchTerm)));
                }

                if (!string.IsNullOrWhiteSpace(SearchAutoRangeType) && SearchAutoRangeType != "All")
                {
                    FilteredAutoRange = new ObservableCollection<AutoRangeModel>(FilteredAutoRange.Where(e => e.type.Equals(SearchAutoRangeType)));
                }

                if (!string.IsNullOrWhiteSpace(SearchAutoRangeUse) && SearchAutoRangeUse != "All")
                {
                    bool bool_is_active = false;
                    if (SearchAutoRangeUse == "True") bool_is_active = true;
                    FilteredAutoRange = new ObservableCollection<AutoRangeModel>(FilteredAutoRange.Where(e => e.is_active.Equals(bool_is_active)));
                }
            }
            else
            {
                FilteredAutoRange = AutoRange;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
