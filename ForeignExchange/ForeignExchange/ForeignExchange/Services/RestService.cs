using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ForeignExchange.Services
{
    public class RestService
    {
        public static HttpClient CreateClient(string url)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<T> Get<T>(string url, HttpClient client = null)
        {
            //if (client == null) 
                client = new HttpClient();
            try
            {
                var response = await client.GetAsync("https://api.coinmarketcap.com/v1/ticker/");//url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return default(T);
        }
    }
}
