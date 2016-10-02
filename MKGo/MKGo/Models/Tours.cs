using SQLite;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    public class Tours
    {
        private SQLiteConnection database;

        public Tours(Database db)
        {
            database = db.GetConnection();
        }
    }
}
