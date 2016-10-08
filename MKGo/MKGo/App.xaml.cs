using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MKGo
{
    public partial class App : Application
    {

        public static object dbLock;
        private static Database database;

        static Items items;
        static Tours tours;
        static CollectionItems collectionItems;


        public App()
        {
            InitializeComponent();
            dbLock = new object();
            database = new Database();
            database.createExampleData();
            MainPage = new MKGo.MainPage();
            //MainPage = new MKGo.MainPage();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
            database.createExampleData();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static Tour GetCurrentTour()
        {
            if (Settings.currentTourId >= 0)
            {
                var currentTour = App.Tours.GetItemWithChildren(Settings.currentTourId);
                return currentTour;
            } else
            {
                return null;
            }
            
        }

        public static Items Items { get
            {
                if(items == null)
                {
                    items = new Items();
                    items.database = database.GetConnection();
                    return items; 
                } else
                {
                    return items;
                }
            }
        }
        public static Tours Tours
        {
            get
            {
                if (tours == null)
                {
                    tours = new Tours();
                    tours.database = database.GetConnection();
                    return tours;
                }
                else
                {
                    return tours;
                }
            }
        }
        public static CollectionItems CollectionItems
        {
            get
            {
                if (collectionItems == null)
                {
                    collectionItems = new CollectionItems();
                    collectionItems.database = database.GetConnection();
                    return collectionItems;
                }
                else
                {
                    return collectionItems;
                }
            }
        }

    }
}
