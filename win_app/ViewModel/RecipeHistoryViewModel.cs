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
        private ObservableCollection<RecipeHistoryModel> _recipeHistory;

        public RecipeHistoryViewModel()
        {
            SetRecipeHistory();
        }

        public ObservableCollection<RecipeHistoryModel> RecipeHistory
        {
            get { return _recipeHistory; }
            set
            {
                _recipeHistory = value;
                OnPropertyChanged(nameof(RecipeHistory));
            }
        }

        private async void SetRecipeHistory()
        {
            HttpResponseMessage response = await GetParamHistory.GetParamHistoryAsync();
            ObservableCollection<RecipeHistoryModel> content = new ObservableCollection<RecipeHistoryModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<RecipeHistoryModel>>(str_content);
                RecipeHistory = new ObservableCollection<RecipeHistoryModel>(content);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
