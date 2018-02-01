using ForeignExchange.Data;
using ForeignExchange.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForeignExchange.Services
{
    public class DataService
    {
        private static DbContext context = new DbContext();

        public static Task<List<Rate>> GetRates()
        {
            return Task.Factory.StartNew(() => context.Rates);
        }

    }
}
