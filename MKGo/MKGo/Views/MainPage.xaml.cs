using System;
using Xamarin.Forms;

namespace MKGo
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Settings.currentTourId < 0)
            {
                var selectTourPage = new SelectTour();
                await Navigation.PushModalAsync(selectTourPage);
            }
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}