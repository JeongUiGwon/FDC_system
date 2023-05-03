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
    public class RecipeViewModel : INotifyPropertyChanged
    {
        public RecipeViewModel()
        {
            SetRecipe();
        }

        private ObservableCollection<RecipeModel> _recipe;
        public ObservableCollection<RecipeModel> Recipes
        {
            get { return _recipe; }
            set
            {
                _recipe = value;
                OnPropertyChanged(nameof(Recipes));
            }
        }

        private ObservableCollection<RecipeModel> _filteredRecipe;
        public ObservableCollection<RecipeModel> FilteredRecipe
        {
            get { return _filteredRecipe; }
            set
            {
                _filteredRecipe = value; 
                OnPropertyChanged(nameof(FilteredRecipe));
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
                FilterRecipe();
            }
        }

        private async void SetRecipe()
        {
            HttpResponseMessage response = await GetRecipe.GetRecipeAsync();
            ObservableCollection<RecipeModel> content = new ObservableCollection<RecipeModel>();

            if (response != null && response.Content != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<RecipeModel>>(str_content);
                Recipes = new ObservableCollection<RecipeModel>(content);
                FilterRecipe();
            }
        }

        private void FilterRecipe()
        {
            if (Recipes != null && Recipes.Any() && !string.IsNullOrWhiteSpace(SearchTerm))
            {
                FilteredRecipe = new ObservableCollection<RecipeModel>(Recipes.Where(e => e.recipe_id.Contains(SearchTerm) || e.recipe_name.Contains(SearchTerm)
                || e.equipment.Contains(SearchTerm) || e.param.Contains(SearchTerm) || e.creator_name.Contains(SearchTerm))); ;
            }
            else
            {
                FilteredRecipe = Recipes;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
