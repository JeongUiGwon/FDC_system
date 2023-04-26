using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PostParams
    {
        public static async Task<HttpResponseMessage> PostParamsAsync(string param_id, string param_name, string param_type, int param_state, int out_count, string creator_name, string equipment)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = "{" + $"\"param_id\": \"{param_id}\", \"param_name\": \"{param_name}\", \"param_type\": \"{param_type}\", " +
                $"\"param_state\": {param_state}, \"out_count\": {out_count}, \"creator_name\": \"{creator_name}\", \"equipment\": \"{equipment}\"" + "}";

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
