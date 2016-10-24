using System;
using System.Threading.Tasks;
//using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace MKGo
{
    public partial class CollectionPage : ContentPage
    {
        async void openScanner()
        {
            var options = new MobileBarcodeScanningOptions();
            options.TryHarder = true;
            options.PossibleFormats.Add(ZXing.BarcodeFormat.QR_CODE);


            var scanPage = new ZXingScannerPage(options);
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
            Task t = new Task(delegate
            {
                while (scanPage.IsScanning)
                {
                    scanPage.AutoFocus();
                    Task.Delay(2000).Wait();

                }
            });

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
            var currentTour = App.CollectionItems.GetItems();
            listView.ItemsSource = currentTour;
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var collectionItem = (CollectionItem)e.SelectedItem;
            var itemPage = new ItemPage();
            itemPage.BindingContext = collectionItem.Item;
            Navigation.PushAsync(itemPage);
        }
    }
}
