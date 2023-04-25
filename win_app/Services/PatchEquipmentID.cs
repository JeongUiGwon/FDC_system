﻿using SOM.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Services
{
    public class PatchEquipmentID
    {
        public static async Task<HttpResponseMessage> PatchEquipmentIDAsync(string equipment_id, string equipment_name, string equipment_state, string modifier_name, string interlock_id)
        {
            HttpClient client = HttpClientSingleton.client;
            string jsonData = "{" + $"\"equipment_id\": \"{equipment_id}\", \"equipment_name\": \"{equipment_name}\", \"equipment_state\": \"{equipment_state}\", " +
                $"\"modifier_name\": \"{modifier_name}\", \"interlock_id\": \"{interlock_id}\"" + "}";
            
            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var request = new HttpRequestMessage(new HttpMethod("PATCH"), Settings.Default.BackendAPIaddress + "/equipments/" + equipment_id + "/")
                {
                    Content = content
                };

                var response = await HttpClient.SendAsync(request);


            }
        }
    }
}
