using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MKGo
{
    public partial class ItemPage : ContentPage
    {

        private Page _removePage;
        public ItemPage()
        {  
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }

        public ItemPage(Page remove): this()
        {
            _removePage = remove;
        }

        protected override void OnAppearing()
        {
            if (_removePage != null)
            {
                Navigation.RemovePage(_removePage);
            }
            
        }

        void saveClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            App.Items.SaveItem(item);
            this.Navigation.PopAsync();
        }

        void deleteClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            App.Items.DeleteItem(item.Id);
            this.Navigation.PopAsync();
        }

        void cancelClicked(object sender, EventArgs e)
        {
            var item = (Item)BindingContext;
            this.Navigation.PopAsync();
        }
    }
}
