using Java.IO;
using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace MKGo
{
    public partial class CollectionPage : ContentPage
    {
        async void openScanner()
        {

          var scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) => {
                    scanPage.IsScanning = false;
                    Device.BeginInvokeOnMainThread(() => {
                        var item = App.CollectionItems.addItem(result.Text);
                        var itemPage = new ItemPage(scanPage);
                        itemPage.BindingContext = item;
                        Navigation.PushAsync(itemPage);

                    });
                };
            scanPage.Title = "Scanner";

                await Navigation.PushAsync(scanPage);

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
            var currentTour = App.CollectionItems.GetItems();
            listView.ItemsSource = currentTour; // change later to collectedItems
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var collectionItem = (CollectionItem)e.SelectedItem;
            var itemPage = new ItemPage();
            itemPage.BindingContext = collectionItem.Item;

            //((App)App.Current).ResumeAtTodoId = todoItem.ID;
            //Debug.WriteLine("setting ResumeAtTodoId = " + todoItem.ID);

            Navigation.PushAsync(itemPage);
        }
    }
}
