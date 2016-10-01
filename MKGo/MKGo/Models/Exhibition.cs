using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo.Models
{
    public class Exhibition
    {
        public Exhibition() { }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Title { get; set; }
    }
}
