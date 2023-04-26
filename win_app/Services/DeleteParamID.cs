using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class DeleteParamID
    {
        public static async Task<HttpResponseMessage> DeleteParamIDAsync(string paramID)
        {
            HttpClient client = HttpClientSingleton.client;

            try
            {
                HttpResponseMessage response = await client.DeleteAsync($"/param/{paramID}/");
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
