using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using MKGo.iOS;
using System.IO;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinIOS;

[assembly: Dependency (typeof (SQLite_iOS))]
namespace MKGo.iOS
{
    class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MKGoSQLite.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(new SQLitePlatformIOS(), path);
            // Return the database connection
            return conn;
        }
    }
}