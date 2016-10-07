using System;
using Xamarin.Forms;

namespace MKGo
{
    public partial class CollectionPage : ContentPage
    {
        public CollectionPage()
        {
            InitializeComponent();

            #region toolbar
            ToolbarItem tbi = null;
            if (Device.OS == TargetPlatform.iOS)
            {
                tbi = new ToolbarItem("+", null, () =>
                {
                    var item = new Item();
                    var itemPage = new ItemPage();
                    itemPage.BindingContext = item;
                    Navigation.PushAsync(itemPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.Android)
            { // BUG: Android doesn't support the icon being null
                tbi = new ToolbarItem("+", "plus", () =>
                {
                    var item = new Item();
                    var itemPage = new ItemPage();
                    itemPage.BindingContext = item;
                    Navigation.PushAsync(itemPage);
                }, 0, 0);
            }
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
            {
                tbi = new ToolbarItem("Add", "add.png", () =>
                {
                    var item = new Item();
                    var itemPage = new ItemPage();
                    itemPage.BindingContext = item;
                    Navigation.PushAsync(itemPage);
                }, 0, 0);
            }

            ToolbarItems.Add(tbi);

            if (Device.OS == TargetPlatform.iOS)
            {
                var tbi2 = new ToolbarItem("?", null, () =>
                {
                    var todos = App.Items.GetItems();
                    var tospeak = "";
                    foreach (var t in todos)
                        tospeak += t.Title + " ";
                    if (tospeak == "") tospeak = "there are no tasks to do";
                }, 0, 0);
                ToolbarItems.Add(tbi2);
            }

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
