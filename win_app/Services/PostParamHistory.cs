using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PostParamHistory
    {
        public static async Task<HttpResponseMessage> PostParamHistoryAsync(string action, string param_id, string old_value = null, string new_value = null)
        {
            HttpClient client = HttpClientSingleton.client;

            string jsonData = $"{{ \"action\": \"{action}\", \"param_id\": \"{param_id}\", \"old_value\": {old_value}, \"new_value\": \"{new_value}\"}}";
            if (new_value == null && old_value != null) jsonData = $"{{ \"action\": \"{action}\", \"param_id\": \"{param_id}\", \"old_value\": {old_value}}}";
            if (new_value != null && old_value == null) jsonData = $"{{ \"action\": \"{action}\", \"param_id\": \"{param_id}\", \"new_value\": {new_value}}}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/param_history/", content);

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
