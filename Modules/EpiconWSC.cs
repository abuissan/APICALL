using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSHARPMVC.Modules;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace CSHARPMVC.Modules
{
    public class EpiconWSC
    {
        public string Address { get; set; }
        public string Service { get; set; }

        public JObject Execute()
        {
            JObject r = null;
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Address)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = client.GetAsync(Service);  // Blocking call! 
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    r = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return r;
        }
    }
}