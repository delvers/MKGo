using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MKGo
{
    public class Database
    {
        static object locker = new object();
        static private SQLiteConnection database;

        public Database()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Item>();
            database.CreateTable<Tour>();
            database.CreateTable<CollectionItem>();
        }

        public SQLiteConnection GetConnection()
        {
            return database;
        }
    }
}
