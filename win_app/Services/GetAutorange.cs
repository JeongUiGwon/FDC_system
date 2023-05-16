using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class GetAutorange
    {
        public static async Task<HttpResponseMessage> GetAutorangeAsync()
        {
            HttpClient client = HttpClientSingleton.client;

            try
            {
                HttpResponseMessage response = await client.GetAsync("/autorange/");
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
