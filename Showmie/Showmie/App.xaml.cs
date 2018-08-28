using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            if (OnboardScreens != null)
            {
                OnboardScreens = new Onboard();
            }

        }
        public Onboard OnboardScreens { get; set; }
        protected override void OnStart()
        {
            if (OnboardScreens != null)
            {
                MainPage = OnboardScreens;
            }
            else
            {
                OnboardScreens = new Onboard();
                MainPage = OnboardScreens;
            }
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            Current.Quit();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes

            if (OnboardScreens != null)
            {
                MainPage = OnboardScreens;
            }
            else
            {
                OnboardScreens = new Onboard();
                MainPage = OnboardScreens;
            }
        }


    }
}
