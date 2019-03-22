using Showmie.Utils;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Showmie.Views
{
    public class OrientationContentPage : ContentPage
    {
        private static DisplayOrientation Orientation = DisplayOrientation.Unknown;
        internal static bool firstPageLoad = true;
        public static int onboardPosition = 0;

        private event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

        public OrientationContentPage()
            : base()
        {
            DeviceDisplay.MainDisplayInfoChanged += OnScreenMetricsChanged;
        }

        void OnMainDisplayInfoChanged(DisplayInfoChangedEventArgs e)
        {
            // Process changes
            var displayInfo = e.DisplayInfo;
        }

        private void OnScreenMetricsChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            DisplayInfo metrics = e.DisplayInfo;
            if (!Orientation.Equals(DisplayOrientation.Unknown) && Orientation != metrics.Orientation)
            {
                Orientation = metrics.Orientation;
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((Orientation == DisplayOrientation.Portrait) ? PageOrientation.Vertical : PageOrientation.Horizontal, this));
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
                DisplayInfo screenMetrics = new DisplayInfo();
                if (screenMetrics.Rotation == DisplayRotation.Rotation0 || screenMetrics.Rotation == DisplayRotation.Rotation180 || screenMetrics.Rotation == DisplayRotation.Unknown)
                {
                    Orientation = DisplayOrientation.Portrait;
                }
                else
                {
                    Orientation = DisplayOrientation.Landscape;
                }
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((Orientation == DisplayOrientation.Portrait) ? PageOrientation.Vertical : PageOrientation.Horizontal, this));
                firstPageLoad = false;
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
