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

        public static string DatabaseFilePath { get
            {
                var sqliteFilename = "MKGoSQLite.db3";
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
                var path = Path.Combine(libraryPath, sqliteFilename);
                return path;
            }
        }

        public static string SeedFile
        {
            get {
                return "MKGoSQLite.db3";
            }
        }

        public static void copyDatabase(string appdir)
        {
            var seedFile = Path.Combine(appdir, SeedFile);
            if (!File.Exists(DatabaseFilePath))
            {
                File.Copy(SeedFile, DatabaseFilePath);
            }
        }

        public SQLiteConnection GetConnection()
        {
            // Create the connection
            var conn = new SQLiteConnection(new SQLitePlatformIOS(), DatabaseFilePath);
            // Return the database connection
            return conn;
        }
    }
}