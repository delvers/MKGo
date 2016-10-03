using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using MKGo.UWP;
using MKGo;
using SQLite.Net.Platform.WinRT;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace MKGo.UWP
{
    class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "MKGoSQLite.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLiteConnection(new SQLitePlatformWinRT() , path);
            return conn;
        }
    }
}
