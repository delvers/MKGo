using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using Xamarin.Forms;

namespace MKGo
{
    public class Item : IModel
    {
        public Item(){}

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string InventoryNumber { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        public string Url { get; set; }

        public int Prio { get; set; }

        [ManyToMany(typeof(TourItem))]
        public List<Tour> Tours { get; set; }

        [ForeignKey(typeof(Room))]
        public int RoomId { get; set; }

        [OneToOne]
        public Room Room { get; set; }

        [ForeignKey(typeof(Quest))]
        public int QuestId { get; set; }

        [OneToOne]
        public Quest Quest { get; set; }

        [Ignore]
        public String ImageSource { get
            {
                return "item" + InventoryNumber.Replace(".","") + "1.jpg";
            }
        }
    }

    public class Items : AbstractModel<Item>{}
}
