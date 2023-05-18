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
    public class AIAnalysisViewModel : INotifyPropertyChanged
    {
        public AIAnalysisViewModel()
        {
            SetAIAnalysis();
            FilterAIAnalysis();
        }

        private ObservableCollection<FullPatternModel> _fullPattern;
        public ObservableCollection<FullPatternModel> FullPattern
        {
            get { return _fullPattern; }
            set
            {
                _fullPattern = value;
                OnPropertyChanged(nameof(FullPattern));
            }
        }

        private ObservableCollection<FullPatternModel> _filteredFullPattern;
        public ObservableCollection<FullPatternModel> FilteredFullPattern
        {
            get { return _filteredFullPattern; }
            set
            {
                _filteredFullPattern = value;
                OnPropertyChanged(nameof(FilteredFullPattern));
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
                FilterAIAnalysis();
            }
        }

        private string _searchType;
        public string SearchType
        {
            get { return _searchType; }
            set
            {
                _searchType = value;
                OnPropertyChanged(nameof(SearchType));
                FilterAIAnalysis();
            }
        }

        private string _searchUse;
        public string SearchUse
        {
            get { return _searchUse; }
            set
            {
                _searchUse = value;
                OnPropertyChanged(nameof(SearchUse));
                FilterAIAnalysis();
            }
        }

        private void SetAIAnalysis()
        {
            FullPattern = new ObservableCollection<FullPatternModel>
            {
                new FullPatternModel(1, 10, 10, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-20), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(2, 10, 20, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-19), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(3, 10, 30, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-18), false, "48EKB0UA1VT54ZS"),
                new FullPatternModel(4, 10, 40, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-17), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(5, 10, 50, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-16), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(6, 10, 60, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-15), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(7, 10, 70, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-14), false, "48EKB0UA1VT54ZS"),
                new FullPatternModel(8, 10, 80, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-13), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(9, 10, 90, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-12), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(10, 10, 10, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-11), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(11, 10, 20, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-10), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(12, 10, 30, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-9), false, "48EKB0UA1VT54ZS"),
                new FullPatternModel(13, 10, 40, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-8), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(14, 10, 50, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-7), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(15, 10, 60, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-6), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(16, 10, 70, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-5), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(17, 10, 80, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-4), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(18, 10, 90, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-3), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(19, 10, 10, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-2), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(20, 10, 20, 5, 5, 100, "Full_Pattern", DateTime.Now.AddMinutes(-1), true, "48EKB0UA1VT54ZS"),
                new FullPatternModel(21, 10, 30, 5, 5, 100, "Full_Pattern", DateTime.Now, true, "48EKB0UA1VT54ZS")
            };
        }

        private void FilterAIAnalysis()
        {
            if (FullPattern != null && FullPattern.Any())
            {
                FilteredFullPattern = new ObservableCollection<FullPatternModel>(FullPattern);

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    FilteredFullPattern = new ObservableCollection<FullPatternModel>(FilteredFullPattern.Where(e => e.param.Contains(SearchTerm)));
                }

                if (!string.IsNullOrWhiteSpace(SearchType) && SearchType != "All")
                {
                    FilteredFullPattern = new ObservableCollection<FullPatternModel>(FilteredFullPattern.Where(e => e.type.Equals(SearchType)));
                }

                if (!string.IsNullOrWhiteSpace(SearchUse) && SearchUse != "All")
                {
                    bool bool_is_active = false;
                    if (SearchUse == "True") bool_is_active = true;
                    FilteredFullPattern = new ObservableCollection<FullPatternModel>(FilteredFullPattern.Where(e => e.is_active.Equals(bool_is_active)));
                }
            }
            else
            {
                FilteredFullPattern = FullPattern;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
