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
        private ObservableCollection<RecipeModel> _recipe;

        public RecipeViewModel()
        {
            SetRecipe();
        }

        public ObservableCollection<RecipeModel> Recipes
        {
            get { return _recipe; }
            set
            {
                _recipe = value;
                OnPropertyChanged(nameof(Recipes));
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
                //content = await response.Content.ReadAsAsync<ObservableCollection<RecipeModel>>(); ;
                Recipes = new ObservableCollection<RecipeModel>(content);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
