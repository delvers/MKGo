using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace MKGo
{
    class Items
    {
        private SQLiteConnection database;

        public Items()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Item>();
        }
    }
}
