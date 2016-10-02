using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using MKGo.Droid;
using System.IO;
using SQLiteNetExtensions;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency (typeof (SQLite_Android))]
namespace MKGo.Droid
{
    class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MKGoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            
            var conn = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }
    }
}