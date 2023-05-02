using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PostRecipe
    {
        public static async Task<HttpResponseMessage> PostRecipeAsync(string recipe_id, string recipe_name, float lsl, float usl, string lsl_interlock_action, string usl_interlock_action, string recipe_use, string creator_name, string equipment, string param)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = $"{{ \"recipe_id\": \"{recipe_id}\", \"recipe_name\": \"{recipe_name}\", \"lsl\": {lsl}, \"usl\": {usl}, \"lsl_interlock_action\": \"{lsl_interlock_action}\"," +
                $"\"usl_interlock_action\": \"{usl_interlock_action}\", \"recipe_use\": \"{recipe_use}\", \"creator_name\": \"{creator_name}\", \"equipment\": \"{equipment}\", \"param\": \"{param}\"}}";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("/recipe/", content);

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
