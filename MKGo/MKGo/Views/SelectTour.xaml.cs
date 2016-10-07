using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MKGo
{
    public partial class SelectTour : ContentPage
    {
        public SelectTour()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = App.Tours.GetItems();
        }

        async void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tour = (Tour)e.SelectedItem;
            if (tour != null)
            {
                Settings.currentTourId = tour.Id;
                await Navigation.PopModalAsync();
            }
            


        }
    }
}
