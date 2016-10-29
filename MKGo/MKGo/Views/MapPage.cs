using System;
using Xamarin.Forms;

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
                var prevTileButton = getMapElement(tile.PrevButtonPosition, "ic_arrow_down.png", loadTile(tile.PrevTile));
                MapLayout.Children.Add(prevTileButton);
            }
            if (tile.hasNextTile()) {
                var nextTileButton = getMapElement(tile.NextButtonPosition, "ic_arrow_up.png", loadTile(tile.NextTile));
                MapLayout.Children.Add(nextTileButton);
            }

            // load items
            var itemOne = getItemView(App.Items.GetItem(3));
            MapLayout.Children.Add(itemOne);
        }

        // returns view for the map image
        protected View getMapBackground(ImageSource imageSource)
        {
            var mapBackground = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = imageSource,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,

            };

            var mapBgView = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };
            mapBgView.Children.Add(mapBackground);

            var MapBgContainer = new AspectRatioContainer
            {
                Content = mapBgView,
                AspectRatio = 1.5894,
            };
            return MapBgContainer;
        }

        // return map element for specific item
        protected View getItemView(Item item)
        {
            Double[] pos = {0.6, 300};
            return getMapElement(pos, ImageSource.FromResource("MKGo.EmbeddedResources.vaseicon.png"), openItem(item));
        }

        // generates itemIcon for the right position and with on tab event
        protected View getMapElement(Double[] position, ImageSource iconSource, EventHandler action)
        {
            var itemIcon = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = iconSource,
                VerticalOptions = LayoutOptions.Start
            };

            var itemView = new Grid();  // workarround for bug 36097 (https://bugzilla.xamarin.com/show_bug.cgi?id=36097)
            itemView.Children.Add(itemIcon);
            AbsoluteLayout.SetLayoutBounds(itemView, new Rectangle(position[0], position[1], 30, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(itemView, AbsoluteLayoutFlags.XProportional);

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