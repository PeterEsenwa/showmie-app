using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Showmie.Models;
using Showmie.Views;
using System.Security;
using Xamarin.Essentials;
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
            
        }
        static User curUser = new User("Peter","Esenwa","designPete","bigjove0@gmail.com", new SecureString(), User.UserTypes.Enthusiast);
        public Onboard OnboardScreens { get; set; }
        public OnboardLandscape OnboardLandscapeScreens { get; set; }

        protected override void OnStart()
        {
            if (OrientationContentPage.firstPageLoad)
            {
                OnboardScreens = new Onboard(true);
                OnboardLandscapeScreens = new OnboardLandscape(true);
            }
            else
            {
                OnboardScreens = new Onboard(false);
                OnboardLandscapeScreens = new OnboardLandscape(false);
            }

            ScreenMetrics metrics = DeviceDisplay.ScreenMetrics;
            switch (metrics.Orientation)
            {
                case ScreenOrientation.Portrait:
                    MainPage = OnboardScreens;
                    break;
                case ScreenOrientation.Unknown:
                    MainPage = OnboardScreens;
                    break;
                case ScreenOrientation.Landscape:
                    MainPage = OnboardLandscapeScreens;
                    break;
                default:
                    MainPage = OnboardScreens;
                    break;
            }
        }

    }
}
