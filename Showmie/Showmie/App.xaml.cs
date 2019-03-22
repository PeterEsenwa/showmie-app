using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Showmie.Views;
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
        public static BindableProperty Username { get; set; }

        //public static User curUser = new User("Peter", "Esenwa", "designPete", "bigjove0@gmail.com", new SecureString(), User.UserTypes.Enthusiast);
        public Onboard OnboardScreens { get; set; }
        public SignupPage Signup { get; set; }
        public OnboardLandscape OnboardLandscapeScreens { get; set; }
        public static double ScreenWidth { get; internal set; }
        public static double ScreenHeight { get; internal set; }
        public static Models.User CurrentUser { get; set; }
        protected override async void OnStart()
        {
            base.OnStart();

            if (Current.Properties.ContainsKey("firstLoad") && !(bool)Current.Properties["firstLoad"])
            {
                NavigationPage navigationPage = new NavigationPage(new LoginPage()) { BarBackgroundColor = Color.White, BarTextColor = Color.Black };
                Current.MainPage = navigationPage;
            }
            else if (Current.Properties.ContainsKey("firstLoad") && (bool)Current.Properties["firstLoad"])
            {
                Current.MainPage = new NavigationPage(new SignupPage()) { BarBackgroundColor = Color.White, BarTextColor = Color.Black };
            }
            else if (!Current.Properties.ContainsKey("firstLoad"))
            {
                OnboardScreens = new Onboard(true);
                OnboardLandscapeScreens = new OnboardLandscape(true);
                DisplayInfo metrics = DeviceDisplay.MainDisplayInfo;
                switch (metrics.Orientation)
                {
                    case DisplayOrientation.Portrait:
                        MainPage = OnboardScreens;
                        break;
                    case DisplayOrientation.Unknown:
                        MainPage = OnboardScreens;
                        break;
                    case DisplayOrientation.Landscape:
                        MainPage = OnboardLandscapeScreens;
                        break;
                    default:
                        MainPage = OnboardScreens;
                        break;
                }
            }
        }

        public static async System.Threading.Tasks.Task SaveProperty(string propertyKey, object propertyValue)
        {
            Current.Properties[propertyKey] = propertyValue;
            await Current.SavePropertiesAsync();
        }


        protected override void OnResume()
        {
            base.OnResume();

        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }


    }
}
