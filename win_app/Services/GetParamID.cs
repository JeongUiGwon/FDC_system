﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class GetParamID
    {
        public static async Task<HttpResponseMessage> GetParamIDAsync(string param_id)
        {
            HttpClient client = HttpClientSingleton.client;

            try
            {
                HttpResponseMessage response = await client.GetAsync($"/param/{param_id}/");
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