using SOM.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public sealed class HttpClientSingleton
    {
        private static readonly HttpClient _client = new HttpClient();

        static HttpClientSingleton()
        {
            _client.BaseAddress = new Uri(Settings.Default.BackendAPIaddress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static HttpClient client
        {
            get
            {
                return _client;
            }
        }
    }
}