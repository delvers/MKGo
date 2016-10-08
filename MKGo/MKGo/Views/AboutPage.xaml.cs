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
    }
}