using Xamarin.Forms;

namespace MKGo
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = App.GetCurrentTour();
        }
    }
}