using SOM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class GetEquipment
    {
        public static async Task<ObservableCollection<EquipmentsModel>> GetEquipmentAsync()
        {
            HttpClient client = HttpClientSingleton.client;
            ObservableCollection<EquipmentsModel> contents = new ObservableCollection<EquipmentsModel>();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            HttpResponseMessage response = await client.GetAsync("/equipment");

            if (response.IsSuccessStatusCode)
            {
                contents = await response.Content.ReadAsAsync<ObservableCollection<EquipmentsModel>>();
            }

            return contents;
        }
    }
}
