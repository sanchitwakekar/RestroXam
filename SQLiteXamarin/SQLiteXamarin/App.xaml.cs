using SQLiteXamarin.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteXamarin
{
    public partial class App : Application
    {
        public static string DatabasePath = string.Empty;
        DBHelper db;
        public App(string databasePath)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            DatabasePath = databasePath;
            db = new DBHelper();
            db.SetupTables();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
