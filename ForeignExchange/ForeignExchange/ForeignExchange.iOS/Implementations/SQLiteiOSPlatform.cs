using Xamarin.Forms;

[assembly: Dependency(typeof(ForeignExchange.iOS.Implementations.SQLiteiOSPlatform))]
namespace ForeignExchange.iOS.Implementations
{
    using ForeignExchange.Interfaces;
    using System;

    public class SQLiteiOSPlatform : ISQLitePlatform
    {
        private string directoryDB;

        public string GetPath(string dbName = "SoulForeignExchange.db3")
        {
            if (string.IsNullOrEmpty(directoryDB))
            {
                var directory = System.Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                directoryDB = System.IO.Path.Combine(directory,"..","Library");
            }

            return directoryDB;
        }
    }
}
