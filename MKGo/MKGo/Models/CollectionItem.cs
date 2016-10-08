using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    public class CollectionItem : IModel
    {
        public CollectionItem() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string questState { get; set; }

        public bool collected { get; set; }

        [ForeignKey(typeof(Item))]
        public int ItemId { get; set; }

        [OneToOne]
        public Item Item { get; set; }

    }

    public class CollectionItems : AbstractModel<CollectionItem> {


        public new List<CollectionItem> GetItems()
        {
            lock (App.dbLock)
            {
                // return collection items with children
                return database.GetAllWithChildren<CollectionItem>();
            }
        }
        public Item addItem(String url)
        {
            var item = database.Table<Item>().FirstOrDefault(x => x.Url == url);

            if (item != null)
            {
                var entry = database.Table<CollectionItem>().FirstOrDefault(x => x.ItemId == item.Id);
                if (entry == null)
                {
                    var collectioItem = new CollectionItem();
                    collectioItem.collected = true;
                    collectioItem.Item = item;
                    database.InsertWithChildren(collectioItem);
                }
            }
            return item;
        }
        public int deleteAll()
        {
            return database.DeleteAll<CollectionItem>();
        }
    }
}
