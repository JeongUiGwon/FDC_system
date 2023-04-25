using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Security.Policy;
using System;

namespace SOM.Services
{
    public class PostEquipment
    {
        public static async Task<HttpResponseMessage> PostEquipmentAsync(string equipment_id, string equipment_name, string equipment_state, string creator_name, string interlock_id)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = "{" + $"\"equipment_id\": \"{equipment_id}\", \"equipment_name\": \"{equipment_name}\", \"equipment_state\": \"{equipment_state}\", " +
                $"\"creator_name\": \"{creator_name}\", \"interlock_id\": \"{interlock_id}\""  + "}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/equipment/", content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Success Response");
                }
                else
                {
                    Console.WriteLine("Fail Response");
                }

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
