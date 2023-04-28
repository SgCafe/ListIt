using ListIt.Models;
using ListIt.Repository;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListIt
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IDataRepository<Product>,SQLiteRepository<Product>>();

            MainPage = new MainPage();
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
