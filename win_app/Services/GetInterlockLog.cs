using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class GetInterlockLog
    {
        public static async Task<HttpResponseMessage> GetInterlockLogAsync(string equipment_id, string param_id, string start_date, string end_date, string factory_id = null, string recipe_id = null, string lot_id = null)
        {
            HttpClient client = HttpClientSingleton.client;
            string query = $"?equipment_id={equipment_id}&param_id={param_id}&start_date={start_date}&end_date={end_date}&factory_id={factory_id}&recipe_id={recipe_id}&lot_id={lot_id}";

            try
            {
                HttpResponseMessage response = await client.GetAsync($"/interlock_log/{query}");
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
