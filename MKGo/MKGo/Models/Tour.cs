using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    class Tour
    {
        public Tour() { }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

    }
}
