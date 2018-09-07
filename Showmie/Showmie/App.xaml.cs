using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Showmie.Utils;
using Showmie.Views;
using System;
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
            if (OrientationContentPage.firstPageLoad)
            {
                OnboardScreens = new Onboard(true);
                OnboardLandscapeScreens = new OnboardLandscape(true);
                //OnboardScreensLandscape = new OnboardLandscape(false);
            }
            else
            {
                OnboardScreens = new Onboard(false);
                OnboardLandscapeScreens = new OnboardLandscape(false);
            }


        }

        public Onboard OnboardScreens { get; set; }
        public OnboardLandscape OnboardLandscapeScreens { get; set; }


        public static void ScaleFontSizes(string Orientation)
        {
            ScreenMetrics metrics = DeviceDisplay.ScreenMetrics;
            double density = metrics.Density;
            // Width (in pixels)
            double width = metrics.Width;

            // Height (in pixels)
            double height = metrics.Height;

            double heightInDp = height / density;
            double widthInDP = width / density;
            double diffHeight = Math.Round(heightInDp / 320, 3);
            double diffWidth = Math.Round(widthInDP / 533, 3);
            double diff = Math.Round(diffHeight * diffWidth, 2);
            if (Orientation == "Landscape")
            {
                FontHandler.AdjustFontSizes(diff * 1.2);
            }
            else if(Orientation == "Portrait")
            {
                FontHandler.AdjustFontSizes(diff);
            }

        }
        //public static OnboardLandscape OnboardScreensLandscape { get; set; }

        protected override void OnStart()
        {
            if (OnboardScreens == null)
            {
                OnboardScreens = new Onboard(true);
                //OnboardScreensLandscape = new OnboardLandscape(false);
            }
            else
            {
                MainPage = OnboardScreens;
            }
        }

        protected override void OnSleep()
        {
            Current.Quit();
        }

        protected override void OnResume()
        {
            if (OnboardScreens == null)
            {
                OnboardScreens = new Onboard(true);
                //OnboardScreensLandscape = new OnboardLandscape(false);
            }
            else
            {
                MainPage = OnboardScreens;
            }
        }


    }
}
