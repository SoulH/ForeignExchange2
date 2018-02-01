using ForeignExchange.Models;
using Plugin.Connectivity;
using System.Threading.Tasks;

namespace ForeignExchange.Services
{
    public class InternetService
    {
        public static Response CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check your internet settings.",
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }

        public static async Task<Response> TestConnection(string url)
        {
            var reachable = await CrossConnectivity.Current.IsReachable(url);
            if (!reachable)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Check your internet settings.",
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
    }
}
