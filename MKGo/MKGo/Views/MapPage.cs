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
                VerticalOptions = LayoutOptions.Fill,
            };
            MapLayout = new AbsoluteLayout
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
            };
            
            var Map = new Image {
                Aspect = Aspect.Fill,
                Source = ImageSource.FromResource("MKGo.EmbeddedResources.defaultmap.png"),
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                
            };

            
            //Map.WidthRequest = MapLayout.Width;

            //double scale = scroll.WidthRequest / Map.WidthRequest;
            var mapGrid = new Grid()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill
            };  // workarround for bug 36097 (https://bugzilla.xamarin.com/show_bug.cgi?id=36097)


            mapGrid.Children.Add(Map);
            //AbsoluteLayout.SetLayoutBounds(mapGrid, new Rectangle(0, 0, 1, AbsoluteLayout.AutoSize));
            //AbsoluteLayout.SetLayoutFlags(mapGrid, AbsoluteLayoutFlags.XProportional);
            //AbsoluteLayout.SetLayoutFlags(mapGrid, AbsoluteLayoutFlags.WidthProportional);

            var obj1 = new Image
            {
                Aspect = Aspect.AspectFill,
                Source = "testIcon.png",
                VerticalOptions = LayoutOptions.Start
            };

            //var ScaleLable = new Label { Text = scale.ToString() + ", "+ Content.Width.ToString() +", "+ Map.WidthRequest.ToString() };


            var objGrid = new Grid();  // workarround for bug 36097 (https://bugzilla.xamarin.com/show_bug.cgi?id=36097)
            objGrid.Children.Add(obj1);
            AbsoluteLayout.SetLayoutBounds(objGrid, new Rectangle(0.5, 100, 50, 50));
            AbsoluteLayout.SetLayoutFlags(objGrid, AbsoluteLayoutFlags.XProportional);

            var tapImage = new TapGestureRecognizer();
            tapImage.Tapped += tapImage_Tapped;
            obj1.GestureRecognizers.Add(tapImage);
            MapLayout.Children.Add(new AspectRatioContainer
            {
                Content = mapGrid,
                AspectRatio = 1.5894
            });
            MapLayout.Children.Add(objGrid);
            //MapLayout.Children.Add(ScaleLable);
            scroll.Content = MapLayout;
            Content = scroll;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tour = App.GetCurrentTour();
            tour.MapFile = "item191921.jpg";
            BindingContext = App.GetCurrentTour();
            
        }
        
        void tapImage_Tapped(object sender, EventArgs e)
        {
            DisplayAlert("Alert", "Tapped Object!", "OK");
        }
    }

    public class AspectRatioContainer : ContentView
    {
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return new SizeRequest(new Size(widthConstraint, widthConstraint * this.AspectRatio));
        }
        public double AspectRatio { get; set; }
    }
}