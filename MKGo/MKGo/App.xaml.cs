using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MKGo
{
    public partial class App : Application
    {

        static Items items;
        static Tours tours;
        static CollectionItems collectionItems;

        public static object dbLock;
        private static Database database;


        public App()
        {
            InitializeComponent();
            dbLock = new object();
            database = new Database();
            MainPage = new MKGo.MainPage();

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

        public static Items Items
        {
            get
            {
                if (items == null)
                {
                    items = new Items(database);
                }
                return items;
            }
        }

        public static Tours Tours
        {
            get
            {
                if (tours == null)
                {
                    tours = new Tours(database);
                }
                return tours;
            }
        }

        public static CollectionItems CollectionItems
        {
            get
            {
                if (collectionItems == null)
                {
                    collectionItems = new CollectionItems(database);
                }
                return collectionItems;
            }
        }

    }
}
