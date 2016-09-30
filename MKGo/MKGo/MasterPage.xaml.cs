using System.Collections.Generic;
using Xamarin.Forms;

namespace MKGo
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Map",
                IconSource = "ic_map_black_36dp.png",
                TargetType = typeof(MapPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "My Collection",
                IconSource = "ic_collections_black_36dp.png",
                TargetType = typeof(CollectionPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "About",
                IconSource = "ic_info_black_24dp.png",
                TargetType = typeof(AboutPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}