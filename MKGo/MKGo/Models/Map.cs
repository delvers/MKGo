using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MKGo
{
    public class Map
    {
        public MapTile[] Tiles;

        public MapTile StartTile;

        public int Id { get; set; }

        public static Map exampleMap()
        {
            var startTile = new MapTile()
            {
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.tile1-10zu16.png"),
                NextButtonPosition = new Double[] { 0.315, 20 },
            };

            Double[] pos = { 0.5, 340 };
            var i = App.Items.GetItem(3);
            i.position = pos;
            startTile.items = new List<Item>();
            startTile.items.Add(i);

            var secondTile = new MapTile()
            {
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.tile2-10zu16.png"),
                PrevTile = startTile,
                PrevButtonPosition = new Double[] { 0.315, 500},
                NextButtonPosition = new Double[] {0.315, 20}
            };

            startTile.NextTile = secondTile;

            var thirdTile = new MapTile()
            {
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.tile3-10zu16.png"),
                PrevTile = secondTile,
                PrevButtonPosition = new Double[] {0.315, 500},
            };

            secondTile.NextTile = thirdTile;


            var map = new Map()
            {
                Tiles = new MapTile[] { startTile, secondTile},
                StartTile = startTile
            };

            return map;
        }
        
    }

    public class MapTile
    {
        public ImageSource ImageSource;
        public MapTile NextTile;
        public MapTile PrevTile;
        public Double[] NextButtonPosition;
        public Double[] PrevButtonPosition;
        public List<Item> items;

        public MapTile()
        {
            items = new List<Item>();
        }

        internal bool hasPrevTile()
        {
            return (PrevTile != null);
        }

        internal bool hasNextTile()
        {
            return (NextTile != null);
        }
    }

}
