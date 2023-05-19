using SOM.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PatchAutorange
    {
        public async static Task<HttpResponseMessage> PatchAutorangeAsync(int autorange_id, float min_range, float max_range, float min_value, float max_value, int interval, int range, string type, bool is_active)
        {
            string str_is_activate = "false";
            if (is_active) str_is_activate = "true";

            HttpClient client = HttpClientSingleton.client;
            string jsonData = $"{{ \"min_range\": {min_range}, \"max_range\": {max_range}, \"min_value\": {min_value}, \"max_value\": {max_value}, \"interval\": {interval}, " +
                $"\"range\": {range}, \"type\": \"{type}\", \"is_active\": {str_is_activate}}}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), $"{Settings.Default.BackendAPIaddress}/autorange/{autorange_id}/")
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
