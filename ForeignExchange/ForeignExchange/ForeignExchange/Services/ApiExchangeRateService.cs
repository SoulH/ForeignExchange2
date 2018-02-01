using ForeignExchange.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForeignExchange.Services
{
    public class ApiExchangeRatesService : InternetService
    {
        public static string URL_BASE = "http://apiexchangerates.azurewebsites.net/";
        static RestClient client = new RestClient(URL_BASE);

        public static Task<List<Rate>> GetRates()
        {
            return Task.Factory.StartNew(() => 
            {
                var request = new RestRequest("api/Rates", Method.GET);
                var response = client.Execute<List<Rate>>(request);
                if (response.IsSuccessful)
                    return response.Data;
                return new List<Rate>();
            });
        }

        public static async Task<Response> TestConnection()
        {
            return await TestConnection(URL_BASE);
        }
    }
}
