using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;

namespace MKGo
{
    public class Item
    {
        public Item()
        {

        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }

        public string InventoryNumber { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

    }
}
