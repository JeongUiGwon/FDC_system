using SOM.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PatchRecipeID
    {
        public async static Task<HttpResponseMessage> PatchRecipeIDAsync(string recipe_id, string recipe_name, float lsl, float usl, string lsl_action, string usl_action, string recipe_use, string modifier_name, string equipment, string param )
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = $"{{ \"recipe_id\": \"{recipe_id}\", \"recipe_name\": \"{recipe_name}\", \"lsl\": {lsl}, \"usl\": {usl}, \"lsl_action\": \"{lsl_action}\"," +
                $"\"usl_action\": \"{usl_action}\", \"recipe_use\": \"{recipe_use}\", \"modifier_name\": \"{modifier_name}\", \"equipment\": \"{equipment}\", \"param\": \"{param}\"}}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{Settings.Default.BackendAPIaddress}/recipe/{recipe_id}/")
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
