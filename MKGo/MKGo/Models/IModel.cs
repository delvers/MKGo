using SQLite.Net;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    public class AbstractModel<T> where T : class, IModel
    {
        public SQLiteConnection database { get; set; }

        public IEnumerable<T> GetItems()
        {
            lock (App.dbLock)
            {
                return (from i in database.Table<T>() select i).ToList();
            }
        }

        public T GetItem(int id)
        {
            lock (App.dbLock)
            {

                return database.Table<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public int SaveItem(T item)
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
                return database.Delete<T>(id);
            }
        }
    }

    public interface IModel
    {
        int Id { get; set; }
    }
}
