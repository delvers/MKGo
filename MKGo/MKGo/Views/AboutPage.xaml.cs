using Xamarin.Forms;
using System;

namespace MKGo
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        public async void OnSelectTour(object sender, EventArgs args)
        {
            var selectTourPage = new SelectTour();
            await Navigation.PushModalAsync(selectTourPage);
        }

        public void OnResetItems(object sender, EventArgs args)
        {
            App.CollectionItems.deleteAll();
        }

        public void OnAddItems(object sender, EventArgs args)
        {
            string[] urls = { "http://sammlungonline.mkg-hamburg.de/de/object/Schnurösengefäß-mit-Schiffsdarstellung/1919.2/dc00125086",
                "http://sammlungonline.mkg-hamburg.de/de/object/Harpokrates/1989.349/dc00126886",
                "http://sammlungonline.mkg-hamburg.de/de/object/Mumienporträt-einer-Frau/1928.42/dc00125645",
                "http://sammlungonline.mkg-hamburg.de/de/object/Oinochoe-Eurymedon-Kanne-oder-Perser-Kanne/1981.173/dc00126657?s=griechen&h=0",
                "http://sammlungonline.mkg-hamburg.de/de/object/Kännchen-in-Form-eines-Afrikanerkopfes/1962.126/dc00126056",
                "http://sammlungonline.mkg-hamburg.de/de/object/Statuette-eines-Buckligen/1949.40/dc00125916" };

            foreach (string url in urls)
            {
                App.CollectionItems.addItem(url);
            }
        }
    }
}