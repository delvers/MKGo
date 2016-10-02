using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    public class CollectionItem
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
}
