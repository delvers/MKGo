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
                Title = "Karte",
                IconSource = "ic_map.png",
                TargetType = typeof(MapPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Meine Sammlung",
                IconSource = "ic_collections.png",
                TargetType = typeof(CollectionPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Impressum",
                IconSource = "ic_info.png",
                TargetType = typeof(AboutPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}