using ListIt.Droid.Services;
using ListIt.Interfaces;
using System;
using System.IO;


[assembly: Xamarin.Forms.Dependency(typeof(DbPathProvider))]
namespace ListIt.Droid.Services
{
    public class DbPathProvider : IDbPathProvider
    {
        public string GetDatabasePath()
        {
            string dbName = "products.db";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, dbName);
        }
    }
}