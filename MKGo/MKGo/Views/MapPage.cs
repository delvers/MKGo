using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace MKGo
{
    public partial class MapPage : ContentPage
    {

        private AbsoluteLayout MapLayout;

        public MapPage()
        {
            Title = "Karte";

            MapLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
            };

            Map map = Map.exampleMap();

            renderTile(map.StartTile);

            var tbi = new ToolbarItem("Add", "ic_fullscreen_black.png", openScanner, 0, 0);
            ToolbarItems.Add(tbi);

            Content = MapLayout;
        }

        // renders MapTile
        protected void renderTile(MapTile tile)
        {
            // load background
            var mapBackground = getMapBackground(tile.ImageSource);
            MapLayout.Children.Add(mapBackground);

            // load navigation buttons
            if (tile.hasPrevTile()) {
                var prevTileButton = getMapElement(tile.PrevButtonPosition, "ic_arrow_down.png", 40, loadTile(tile.PrevTile));
                MapLayout.Children.Add(prevTileButton);
            }
            if (tile.hasNextTile()) {
                var nextTileButton = getMapElement(tile.NextButtonPosition, "ic_arrow_up.png", 40, loadTile(tile.NextTile));
                MapLayout.Children.Add(nextTileButton);
            }

            // load items
            foreach (Item i in tile.items)
            {
                MapLayout.Children.Add(getItemView(i));
            }

        }

        // returns view for the map image
        protected View getMapBackground(ImageSource imageSource)
        {
            var mapBackground = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = imageSource,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };

            var mapBgView = new Grid
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,

            };
            mapBgView.Children.Add(mapBackground);

            var MapBgContainer = new AspectRatioContainer
            {
                Content = mapBgView,
                AspectRatio = 1.454545,
            };

            AbsoluteLayout.SetLayoutBounds(MapBgContainer, new Rectangle(0,0,1,AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(MapBgContainer, AbsoluteLayoutFlags.WidthProportional);
            

            return MapBgContainer;
        }

        // return map element for specific item
        protected View getItemView(Item item)
        {
            String icon;
            if (App.CollectionItems.inCollection(item))
            {
                icon = "MKGo.EmbeddedResources.vaseicon.png";
            } else
            {
                icon = "MKGo.EmbeddedResources.questionmark.png";
            }
            return getMapElement(item.position, ImageSource.FromResource(icon), 30, openItem(item));
        }

        // generates itemIcon for the right position and with on tab event
        protected View getMapElement(Double[] position, ImageSource iconSource, int height, EventHandler action)
        {
            var itemIcon = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = iconSource,
                VerticalOptions = LayoutOptions.Start
            };

            var itemView = new Grid();  // workarround for bug 36097 (https://bugzilla.xamarin.com/show_bug.cgi?id=36097)
            itemView.Children.Add(itemIcon);
            AbsoluteLayout.SetLayoutBounds(itemView, new Rectangle(position[0], position[1], height, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(itemView, AbsoluteLayoutFlags.PositionProportional);
            

            var tapIcon = new TapGestureRecognizer();
            tapIcon.Tapped += action;
            itemIcon.GestureRecognizers.Add(tapIcon);

            return itemView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = App.GetCurrentTour();
        }

        // creates EventHandler to load new Map Tile
        protected EventHandler loadTile(MapTile tile)
        {
            return (object sender, EventArgs e) =>
            {
                MapLayout.Children.Clear();
                renderTile(tile);
            };
        }

        // creates EventHandler for taping ItemIcons
        protected EventHandler openItem(Item item)
        {
            return (object sender, EventArgs e) =>
            {
                var itemPage = new ItemPage();
                itemPage.BindingContext = item;
                Navigation.PushAsync(itemPage);
                //DisplayAlert("Alert", item.Title, "OK");
            };
        }

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
    }


    // used to scale Images
    public class AspectRatioContainer : ContentView
    {
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            //return base.OnMeasure(widthConstraint, widthConstraint * this.AspectRatio);
            //HeightRequest = widthConstraint * this.AspectRatio;
            return new SizeRequest(new Size(widthConstraint, widthConstraint * this.AspectRatio));
        }
        

        public double AspectRatio { get; set; }
    }
}