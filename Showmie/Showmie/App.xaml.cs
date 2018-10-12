using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Showmie.Models;
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
        public static User NewUser { get; set; }
        public static BindableProperty Username { get; set; }

        public static User curUser = new User("Peter", "Esenwa", "designPete", "bigjove0@gmail.com", new SecureString(), User.UserTypes.Enthusiast);
        public Onboard OnboardScreens { get; set; }
        public OnboardLandscape OnboardLandscapeScreens { get; set; }
        public static double ScreenWidth { get; internal set; }
        public static double ScreenHeight { get; internal set; }

        protected override void OnStart()
        {
            if (Current.Properties.ContainsKey("current_page") && (Current.Properties["current_page"] != null || !Current.Properties["current_page"].Equals(null)))
            {
                System.Type lastPageType = (System.Type)Current.Properties["current_page"];

            }
            else
            {
                OnboardScreens = new Onboard(true);
                OnboardLandscapeScreens = new OnboardLandscape(true);
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



        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            Current.Properties["current_page"] = MainPage.GetType();
            base.OnSleep();
        }


    }
}
