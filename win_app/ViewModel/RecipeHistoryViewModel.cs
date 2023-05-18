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
    public class RecipeHistoryViewModel : INotifyPropertyChanged
    {
        public RecipeHistoryViewModel()
        {
            SetRecipeHistory();
        }

        private ObservableCollection<RecipeHistoryModel> _recipeHistory;
        public ObservableCollection<RecipeHistoryModel> RecipeHistory
        {
            get { return _recipeHistory; }
            set
            {
                _recipeHistory = value;
                OnPropertyChanged(nameof(RecipeHistory));
            }
        }

        private ObservableCollection<RecipeHistoryModel> _filteredRecipeHistory;
        public ObservableCollection<RecipeHistoryModel> FilteredRecipeHistory
        {
            get { return _filteredRecipeHistory; }
            set
            {
                _filteredRecipeHistory = value; 
                OnPropertyChanged(nameof(FilteredRecipeHistory));
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

        private async void SetRecipeHistory()
        {
            HttpResponseMessage response = await GetRecipeHistory.GetRecipeHistoryAsync();
            ObservableCollection<RecipeHistoryModel> content = new ObservableCollection<RecipeHistoryModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<RecipeHistoryModel>>(str_content);
                RecipeHistory = new ObservableCollection<RecipeHistoryModel>(content);
                FilterParamHistory();
            }
        }
        private void FilterParamHistory()
        {
            if (RecipeHistory != null && RecipeHistory.Any() && !string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredRecipeHistory = new ObservableCollection<RecipeHistoryModel>(RecipeHistory.Where(e => e.action.Contains(SearchTerm) || e.recipe.Contains(SearchTerm)));
            }
            else
            {
                FilteredRecipeHistory = RecipeHistory;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
