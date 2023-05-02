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
    public class DashboardViewModel : INotifyPropertyChanged
    {
        public DashboardViewModel() 
        {
            GetEquipmentsData();
            GetParamsData();
            GetRecipeData();
        }

        private int _equipmentCount;
        public int EquipmentCount
        {
            get { return _equipmentCount; }
            set
            {
                _equipmentCount = value;
                OnPropertyChanged(nameof(EquipmentCount));
            }
        }

        private int _paramsCount;
        public int ParamsCount
        {
            get { return _paramsCount; }
            set
            {
                _paramsCount = value;
                OnPropertyChanged(nameof(ParamsCount));
            }
        }

        private int _recipeCount;
        public int RecipeCount
        {
            get { return _recipeCount; }
            set
            {
                _recipeCount = value;
                OnPropertyChanged(nameof(RecipeCount));
            }
        }

        private async void GetEquipmentsData()
        {
            HttpResponseMessage response = await GetEquipment.GetEquipmentAsync();
            ObservableCollection<EquipmentsModel> content = new ObservableCollection<EquipmentsModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<EquipmentsModel>>(str_content);
                EquipmentCount = content.Count;
            }
            else
            {
                EquipmentCount = 0;
            }
        }

        private async void GetParamsData()
        {
            HttpResponseMessage response = await GetParams.GetParamsAsync();
            ObservableCollection<ParamsModel> content = new ObservableCollection<ParamsModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<ParamsModel>>(str_content);
                ParamsCount = content.Count;
            }
            else
            {
                ParamsCount = 0;
            }
        }

        private async void GetRecipeData()
        {
            HttpResponseMessage response = await GetRecipe.GetRecipeAsync();
            ObservableCollection<RecipeModel> content = new ObservableCollection<RecipeModel>();

            if (response != null)
            {
                string str_content = await response.Content.ReadAsStringAsync();
                content = JsonConvert.DeserializeObject<ObservableCollection<RecipeModel>>(str_content);
                RecipeCount = content.Count;
            }
            else
            {
                RecipeCount = 0;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
