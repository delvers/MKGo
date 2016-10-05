using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKGo
{
    public class Room
    {
        public Room(string title) { }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        [ForeignKey(typeof(Exhibition))]
        public int ExhibitionId { get; set; }
    }
}
