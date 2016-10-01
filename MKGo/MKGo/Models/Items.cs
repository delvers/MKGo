using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace MKGo
{
    public class Items
    {
        static object locker = new object();
        private SQLiteConnection database;

        public Items()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Item>();
        }

        public IEnumerable<Item> GetItems()
        {
            return (from i in database.Table<Item>() select i).ToList();
        }
        public IEnumerable<Item> GetItemsNotDone()
        {
            return database.Query<Item>("SELECT * FROM [Item] WHERE [Done] = 0");
        }
        public Item GetItem(int id)
        {
            return database.Table<Item>().FirstOrDefault(x => x.ID == id);
        }

        public int SaveItem(Item item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    database.Update(item);
                    return item.ID;
                }
                else
                {
                    return database.Insert(item);
                }
            }
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Item>(id);
        }
    }
}
