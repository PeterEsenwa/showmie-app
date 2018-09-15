using Showmie.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Showmie.Utils
{
    internal class PageOrientationEventArgs : EventArgs
    {
        public static PageOrientation _oldOrientation = PageOrientation.Unknown;
        public PageOrientation Orientation { get; }

        public PageOrientationEventArgs(PageOrientation orientation, ContentPage currentPage)
        {
            Orientation = orientation;
            if (_oldOrientation.Equals(PageOrientation.Unknown) || !(_oldOrientation == Orientation))
            {
                _oldOrientation = Orientation;
                if (Orientation == PageOrientation.Horizontal)
                {
                    ScaleFontSizes("Landscape");
                }
                else
                {
                    ScaleFontSizes("Portrait");
                }
                if (currentPage is OrientationContentPage && (currentPage is OnboardLandscape || currentPage is Onboard))
                {
                    if (Orientation == PageOrientation.Horizontal)
                    {
                        Application.Current.MainPage = new OnboardLandscape(isFirstLoad: OrientationContentPage.firstPageLoad, boardPosition: OrientationContentPage.onboardPosition);
                    }
                    else
                    {
                        Application.Current.MainPage = new Onboard(OrientationContentPage.firstPageLoad, OrientationContentPage.onboardPosition);
                    }
                }
            }

        }

        public static double oldLandDiff = 1;
        public static double oldPortDiff = 1;
        public static void ScaleFontSizes(string Orientation)
        {
            if (Orientation == "Portrait")
            {
                if (OrientationContentPage.firstPageLoad)
                {
                    ScreenMetrics metrics = DeviceDisplay.ScreenMetrics;
                    double density = metrics.Density;
                    // Width (in pixels)
                    double width = metrics.Width;

                    // Height (in pixels)
                    double height = metrics.Height;

                    double heightInDp = height / density;
                    double widthInDP = width / density;
                    double diffHeight = Math.Round(heightInDp / 533, 3);
                    double diffWidth = Math.Round(widthInDP / 320, 3);
                    double diff = Math.Round(diffHeight * diffWidth, 2);
                    oldPortDiff = diff;
                    OrientationContentPage.firstPageLoad = false;
                    FontHandler.AdjustFontSizes(diff);
                }
                else
                {
                    FontHandler.AdjustFontSizes(1 / 1.2);
                }
            }
            else if (Orientation == "Landscape")
            {
                if (OrientationContentPage.firstPageLoad)
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
                    oldLandDiff = diff;
                    OrientationContentPage.firstPageLoad = false;
                    FontHandler.AdjustFontSizes(diff * 1.2);
                }
                else
                {
                    FontHandler.AdjustFontSizes(1.2);
                }
            }

        }
    }

    public enum PageOrientation
    {
        Horizontal = 0,
        Vertical = 1,
        Unknown = -1
    }
}
