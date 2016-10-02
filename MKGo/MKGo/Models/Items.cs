using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using SQLite.Net;

namespace MKGo
{
    public class Items
    {
        private SQLiteConnection database;

        public Items(Database db)
        {
            database = db.GetConnection();
        }

        public IEnumerable<Item> GetItems()
        {
            lock (App.dbLock)
            {
                return (from i in database.Table<Item>() select i).ToList();
            }
        }
        public IEnumerable<Item> GetItemsNotDone()
        {
            lock (App.dbLock)
            {
                return database.Query<Item>("SELECT * FROM [Item] WHERE [Done] = 0");
            }
        }
        public Item GetItem(int id)
        {
            lock (App.dbLock)
            {
               
                return database.Table<Item>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveItem(Item item)
        {
            lock (App.dbLock)
            {
                if (item.Id != 0)
                {
                    database.Update(item);
                    return item.Id;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            lock (App.dbLock)
            {
                return database.Delete<Item>(id);
            }
        }
    }
}
