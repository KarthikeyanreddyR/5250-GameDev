using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GameDev.Views;
using GameDev.Services;
using SQLite;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GameDev
{
    public partial class App : Application
    {
        static SQLiteAsyncConnection _db;

        public static SQLiteAsyncConnection Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("GameDevDB.db3"));
                }
                return _db;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
