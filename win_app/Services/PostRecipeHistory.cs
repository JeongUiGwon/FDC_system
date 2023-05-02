using FirebaseAdmin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PostRecipeHistory
    {
        public static async Task<HttpResponseMessage> PostRecipeHistoryAsync(string action, string recipe, string old_value = null, string new_value = null)
        {
            HttpClient client = HttpClientSingleton.client;

            string jsonData = $"{{ \"action\": \"{action}\", \"recipe\": \"{recipe}\", \"old_value\": {old_value}, \"new_value\": {new_value}}}";
            if (new_value == null && old_value != null) jsonData = $"{{ \"action\": \"{action}\", \"recipe\": \"{recipe}\", \"old_value\": {old_value}}}";
            if (new_value != null && old_value == null) jsonData = $"{{ \"action\": \"{action}\", \"recipe\": \"{recipe}\", \"new_value\": {new_value}}}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/recipe_history/", content);

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
