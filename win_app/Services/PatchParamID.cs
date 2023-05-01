using SOM.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PatchParamID
    {
        public async static Task<HttpResponseMessage> PatchParamIDAsync(string param_id, string param_name, string param_level, string param_state, string modifier_name, string equipment)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = "{" + $"\"param_id\": \"{param_id}\", \"param_name\": \"{param_name}\", \"param_level\": \"{param_level}\", " +
                $"\"param_state\": \"{param_state}\", \"modifier_name\": \"{modifier_name}\", \"equipment\": \"{equipment}\"" + "}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{Settings.Default.BackendAPIaddress}/param/{param_id}/")
                {
                    Content = content
                };

                HttpResponseMessage response = await client.SendAsync(request);

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
    }
}
