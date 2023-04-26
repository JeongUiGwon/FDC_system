using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PostParam
    {
        public static async Task<HttpResponseMessage> PostParamAsync(string param_id, string param_name, string param_level, string param_state, string creator_name, string equipment)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = "{" + $"\"param_id\": \"{param_id}\", \"param_name\": \"{param_name}\", \"param_level\": \"{param_level}\", " +
                $"\"param_state\": \"{param_state}\", \"creator_name\": \"{creator_name}\", \"equipment\": \"{equipment}\"" + "}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/param/", content);

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
