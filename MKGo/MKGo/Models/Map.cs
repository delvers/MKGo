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
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.defaultmap.png")
            };

            var secondTile = new MapTile()
            {
                ImageSource = ImageSource.FromResource("MKGo.EmbeddedResources.defaultmap.png"),
                PrevTile = startTile,
                PrevButtonPosition = new Double[] { 0.5, 400}
            };

            startTile.NextTile = secondTile;
            startTile.NextButtonPosition = new Double[] { 0.45, 20};

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
