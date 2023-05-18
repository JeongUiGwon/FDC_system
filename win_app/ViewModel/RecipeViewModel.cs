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

        private string _searchLslAction;
        public string SearchLslAction
        {
            get { return _searchLslAction; }
            set
            {
                _searchLslAction = value;
                OnPropertyChanged(nameof(SearchLslAction));
                FilterRecipe();
            }
        }

        private string _searchUslAction;
        public string SearchUslAction
        {
            get { return _searchUslAction; }
            set
            {
                _searchUslAction = value;
                OnPropertyChanged(nameof(SearchUslAction));
                FilterRecipe();
            }
        }

        private string _searchRecipeUse;
        public string SearchRecipeUse
        {
            get { return _searchRecipeUse; }
            set
            {
                _searchRecipeUse = value;
                OnPropertyChanged(nameof(SearchRecipeUse));
                FilterRecipe();
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
            if (Recipes != null && Recipes.Any())
            {
                FilteredRecipe = new ObservableCollection<RecipeModel>(Recipes);

                if (!string.IsNullOrWhiteSpace(SearchTerm))
                {
                    FilteredRecipe = new ObservableCollection<RecipeModel>(FilteredRecipe.Where(e => e.recipe_id.Contains(SearchTerm) || e.recipe_name.Contains(SearchTerm)
                    || e.equipment.Contains(SearchTerm) || e.param.Contains(SearchTerm) || e.creator_name.Contains(SearchTerm))); ;
                }

                if (!string.IsNullOrWhiteSpace(SearchLslAction) && SearchLslAction != "All")
                {
                    FilteredRecipe = new ObservableCollection<RecipeModel>(FilteredRecipe.Where(e => e.lsl_interlock_action.Equals(SearchLslAction)));
                }

                if (!string.IsNullOrWhiteSpace(SearchUslAction) && SearchUslAction != "All")
                {
                    FilteredRecipe = new ObservableCollection<RecipeModel>(FilteredRecipe.Where(e => e.usl_interlock_action.Equals(SearchUslAction)));
                }

                if (!string.IsNullOrWhiteSpace(SearchRecipeUse) && SearchRecipeUse != "All")
                {
                    FilteredRecipe = new ObservableCollection<RecipeModel>(FilteredRecipe.Where(e => e.recipe_use.Equals(SearchRecipeUse)));
                }

                if (!string.IsNullOrWhiteSpace(SearchEquipment) && SearchEquipment != "All")
                {
                    FilteredRecipe = new ObservableCollection<RecipeModel>(FilteredRecipe.Where(e => e.equipment.Equals(SearchEquipment)));
                }
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
