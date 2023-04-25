using SOM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

namespace SOM.Services
{
    public class DeleteEquipmentID
    {
        public static async Task<HttpResponseMessage> DeleteEquipmentIDAsync(string equip_id)
        {
            HttpClient client = HttpClientSingleton.client;

            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/equipment/" + equip_id);
                return response;
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
