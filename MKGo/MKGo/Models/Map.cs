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
                NextButtonPosition = new Double[] { 0.315, 0.07 },
            };


            var i1 = App.Items.GetItem(1);
            i1.position = new Double[] { 0.75, 0.38};
            var i2 = App.Items.GetItem(2);
            i2.position = new Double[] { 0.5, 0.53 };
            var i3 = App.Items.GetItem(3);
            i3.position = new Double[] { 0.35, 0.85 };
            var i4 = App.Items.GetItem(4);
            i4.position = new Double[] { 0.46, 0.7 };
            var i5 = App.Items.GetItem(5);
            i5.position = new Double[] { 0.46, 0.85 };
            var i6 = App.Items.GetItem(6);
            i6.position = new Double[] { 0.18, 0.64 };
            var i7 = App.Items.GetItem(7);
            i7.position = new Double[] { 0.45, 0.45 };


            startTile.items = new List<Item> {i1, i2, i3};


            var secondTile = new MapTile()
            {
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.tile2-10zu16.png"),
                PrevTile = startTile,
                PrevButtonPosition = new Double[] { 0.315, 0.93},
                NextButtonPosition = new Double[] {0.315, 0.07}
            };

            secondTile.items = new List<Item> { i4, i5 };
            startTile.NextTile = secondTile;


            var thirdTile = new MapTile()
            {
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.tile3-10zu16.png"),
                PrevTile = secondTile,
                PrevButtonPosition = new Double[] {0.315, 0.93},
            };
            thirdTile.items = new List<Item> { i6, i7 };
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
