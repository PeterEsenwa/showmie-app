using Showmie.Utils;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Showmie.Views
{
    public class OrientationContentPage : ContentPage
    {
        private static ScreenOrientation Orientation = ScreenOrientation.Unknown;
        internal static bool firstPageLoad = true;
        public static int onboardPosition = 0;

        private event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

        public OrientationContentPage()
            : base()
        {
            DeviceDisplay.ScreenMetricsChanged += OnScreenMetricsChanged;
        }

        private void OnScreenMetricsChanged(object sender, ScreenMetricsChangedEventArgs e)
        {
            ScreenMetrics metrics = e.Metrics;
            if (!Orientation.Equals(ScreenOrientation.Unknown) && Orientation != metrics.Orientation)
            {
                Orientation = metrics.Orientation;
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((Orientation == ScreenOrientation.Portrait) ? PageOrientation.Vertical : PageOrientation.Horizontal, this));
            }
            else { Orientation = metrics.Orientation; }
        }

        protected static void OnboardPositionChanged(int newPosition)
        {
            onboardPosition = newPosition;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (firstPageLoad)
            {
                ScreenMetrics screenMetrics = new ScreenMetrics();
                if (screenMetrics.Rotation == ScreenRotation.Rotation0 || screenMetrics.Rotation == ScreenRotation.Rotation180)
                {
                    Orientation = ScreenOrientation.Portrait;
                }
                else
                {
                    Orientation = ScreenOrientation.Landscape;
                }
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((Orientation == ScreenOrientation.Portrait) ? PageOrientation.Vertical : PageOrientation.Horizontal, this));
            }

        }

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        public void SetMainPage(Page page)
        {
            Application.Current.MainPage = page;
        }
    }
}
