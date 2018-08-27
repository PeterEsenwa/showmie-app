using Showmie;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Showmie
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            AppCenter.Start("android=92233719-d584-4656-9fd8-27003c82e33b;",
                  typeof(Analytics), typeof(Crashes));
            MainPage = new Onboard();

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
