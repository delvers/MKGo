using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MKGo
{
    class Item
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
