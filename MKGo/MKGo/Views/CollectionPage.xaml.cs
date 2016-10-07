using Java.IO;
using System;
using Xamarin.Forms;

namespace MKGo
{
    public partial class CollectionPage : ContentPage
    {
        private async void openScanner()
        {

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            scanner.BottomText = "Finde und scanne deinen nächsten Fund!";
            scanner.TopText = "Scanner";
            var result = await scanner.Scan();

            if (result != null)
                 Title = result.Text;

        }

        public CollectionPage()
        {
            InitializeComponent();

            #region toolbar
            ToolbarItem tbi = null;

            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, openScanner, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", openScanner, 0, 0);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                tbi = new ToolbarItem("Add", "add.png", openScanner, 0, 0);
            }

            ToolbarItems.Add(tbi);
            #endregion

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // reset the 'resume' id, since we just want to re-start here
            //((App)App.Current).ResumeAtTodoId = -1;
            var currentTour = App.GetCurrentTour();
            listView.ItemsSource = currentTour.Items; // change later to collectedItems
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Item)e.SelectedItem;
            var itemPage = new ItemPage();
            itemPage.BindingContext = item;

            //((App)App.Current).ResumeAtTodoId = todoItem.ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + todoItem.ID);

            Navigation.PushAsync(itemPage);
        }
    }
}
