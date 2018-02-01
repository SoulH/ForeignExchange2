using ForeignExchange.Interfaces;
using SQLite;
using System;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;
using ForeignExchange.Models;

namespace ForeignExchange.Data
{
    public class DbContext : IDisposable
    {
        public SQLiteConnection Db { get; private set; }
        public List<Rate> Rates { get { return Db.Table<Rate>().ToList(); } }

        public DbContext()
        {
            var ds = DependencyService.Get<ISQLitePlatform>();
            Db = new SQLiteConnection(ds.GetPath());
            Db.CreateTable<Rate>();
        }

        public void Migrate()
        {
            
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
