using Xamarin.Forms;

[assembly: Dependency(typeof(App.Droid.Implementations.SQLiteAndroidPlatform))]
namespace App.Droid.Implementations
{
    using App.Droid.Implementations;
    using ForeignExchange.Interfaces;
    using System.IO;

    public class SQLiteAndroidPlatform : ISQLitePlatform
    {
        public string GetPath(string dbName = "SoulForeignExchange.db3")
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
        }
    }
}