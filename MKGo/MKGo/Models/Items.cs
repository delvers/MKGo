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

        public string Detail { get; set; }

        public string Detail_en { get; set; }

        public string Material { get; set; }

        public string Findspot { get; set; }

        public string Creationdate { get; set; }

        public string Era { get; set; }

        public string InventoryNumber { get; set; }

        [MaxLength(600)]
        public string Description { get; set; }

        public string Url { get; set; }

        public int Prio { get; set; }

        [ManyToMany(typeof(TourItem))]
        public List<Tour> Tours { get; set; }

        [ForeignKey(typeof(Room))]
        public int RoomId { get; set; }

        [Ignore]
        public double[] position { get; set; }

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

                var filename = "MKGo.EmbeddedResources.item" + InventoryNumber.Replace(".", "") + "1.jpg";
				var source = ImageSource.FromResource(filename);
                return source;
            }
        }

        [Ignore]
        public ImageSource IconSource
        {
            get
            {
                if (InventoryNumber == null)
                {
                    return "test";
                }

                var filename = "MKGo.EmbeddedResources.item" + InventoryNumber.Replace(".", "") + "1_small.jpg";
                var source = ImageSource.FromResource(filename);
                return source;
            }
        }
    }

    public class Items : AbstractModel<Item>{}
}
