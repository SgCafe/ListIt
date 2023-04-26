using Foundation;
using ListIt.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace ListIt.iOS.Services
{
    public class DbPathProvider : IDbPathProvider
    {
        public string GetDatabasePath()
        {
            string dbName = "product.db";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library");
            return Path.Combine(libraryPath, dbName);
        }
    }
}