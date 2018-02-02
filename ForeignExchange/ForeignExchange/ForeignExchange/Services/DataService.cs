using ForeignExchange.Data;
using ForeignExchange.Models;
using System;
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

        internal static Task SetRates(List<Rate> list)
        {
            return Task.Factory.StartNew(() =>
            {
                context.Db.DeleteAll<Rate>();
                context.Db.InsertAll(list, true);
            });
        }
    }
}
