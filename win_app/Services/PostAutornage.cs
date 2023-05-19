using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PostAutornage
    {
        public static async Task<HttpResponseMessage> PostAutorangeAsync(float min_range, float max_range, float min_value, float max_value, int interval, int range, string type, string is_active, string param)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = $"{{ \"min_range\": {min_range}, \"max_range\": {max_range}, \"min_value\": {min_value}, \"max_value\": {max_value}, \"interval\": {interval}, " +
                $"\"range\": {range}, \"type\": \"{type}\", \"is_active\": {is_active}, \"param\": \"{param}\"}}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/autorange/", content);

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
