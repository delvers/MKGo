using System;
using Xamarin.Forms;

namespace MKGo
{
    public partial class MapPage : ContentPage
    {

        private AbsoluteLayout MapLayout;
        public MapPage()
        {
            Title = "Map";

            var scroll = new ScrollView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
            };

            MapLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
            };
            
            var Map = new Image {
                Aspect = Aspect.AspectFill,
                Source = ImageSource.FromResource("MKGo.EmbeddedResources.defaultmap.png"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Fill,
                
            };

            var MapGrid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,

            };
            MapGrid.Children.Add(Map);

            var MapContainer = new AspectRatioContainer
            {
                Content = MapGrid,
                AspectRatio = 1.5894,
            };

            AbsoluteLayout.SetLayoutBounds(MapContainer, new Rectangle(0, 0, 1, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(MapContainer, AbsoluteLayoutFlags.WidthProportional);

            var obj1 = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = ImageSource.FromResource("MKGo.EmbeddedResources.vaseicon.png"),
                VerticalOptions = LayoutOptions.Start
            };

            var objGrid = new Grid();  // workarround for bug 36097 (https://bugzilla.xamarin.com/show_bug.cgi?id=36097)
            objGrid.Children.Add(obj1);
            AbsoluteLayout.SetLayoutBounds(objGrid, new Rectangle(0.6, 200, 30, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(objGrid, AbsoluteLayoutFlags.XProportional);

            var tapImage = new TapGestureRecognizer();
            tapImage.Tapped += openItem(App.Items.GetItem(3));
            obj1.GestureRecognizers.Add(tapImage);

            MapLayout.Children.Add(MapContainer);
            MapLayout.Children.Add(objGrid);

            //MapLayout.Children.Add(ScaleLable);
            //scroll.Content = MapLayout;
            //Content = scroll;
            Content = MapLayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = App.GetCurrentTour();
            
        }

        EventHandler openItem(Item item)
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