using SQLite;
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
        public int ID { get; set; }

        public string questState { get; set; }
    }
}
