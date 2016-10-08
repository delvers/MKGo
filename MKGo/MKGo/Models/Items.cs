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
        public ImageSource ImageSource { get
            {
                if (InventoryNumber == null)
                {
                    return "test";
                }

                var filename = "item" + InventoryNumber.Replace(".", "") + "1.jpg";
                var source = Device.OnPlatform(
                iOS: ImageSource.FromFile("Images/"+filename),
                Android: ImageSource.FromFile(filename),
                WinPhone: ImageSource.FromFile("Images/"+filename));
                return source;
            }
        }
    }

    public class Items : AbstractModel<Item>{}
}
