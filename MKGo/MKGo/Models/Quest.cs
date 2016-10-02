using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    public class Quest
    {
        public Quest() { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
