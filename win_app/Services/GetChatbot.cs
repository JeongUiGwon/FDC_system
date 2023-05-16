using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class GetChatbot
    {
        public static async Task<HttpResponseMessage> GetChatbotAsync(string questionText)
        {
            HttpClient client = HttpClientSingleton.client;

            try
            {
                HttpResponseMessage response = await client.GetAsync($"/chatbot?question={questionText}");
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
