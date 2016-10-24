using System;
using Xamarin.Forms;

namespace MKGo
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {


            InitializeComponent();
            var tbi = new ToolbarItem("Score: "+ Settings.Score, "score.png", ()=> { DisplayAlert("Score",Settings.Score.ToString(),"OK"); } , 0, 0);
            ToolbarItems.Add(tbi);

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