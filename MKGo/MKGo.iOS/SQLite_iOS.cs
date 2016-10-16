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
using Foundation;


[assembly: Dependency (typeof (SQLite_iOS))]
namespace MKGo.iOS
{
    class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }

		private static string DatabaseFileName
		{
			get
			{
				return "MKGoSQLite.db3";
			}
		}

        private static string DatabaseFilePath 
		{ 
			get
            {
                string documentsFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string dbFolderPath = Path.Combine(documentsFolderPath, "..", "Library", "Databases");

				if (!Directory.Exists(dbFolderPath))
				{
					Directory.CreateDirectory(dbFolderPath);
				}

                var path = Path.Combine(dbFolderPath, DatabaseFileName);
                return path;
            }
        }

        public SQLiteConnection GetConnection()
        {
			// will create the database, if not existant yet
            var conn = new SQLiteConnection(new SQLitePlatformIOS(), DatabaseFilePath);
            return conn;
        }
    }
}