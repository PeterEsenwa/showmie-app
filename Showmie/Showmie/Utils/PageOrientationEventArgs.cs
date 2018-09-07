using Showmie.Views;
using System;
using Xamarin.Forms;

namespace Showmie.Utils
{
    internal class PageOrientationEventArgs : EventArgs
    {
        public PageOrientationEventArgs(PageOrientation orientation, ContentPage currentPage)
        {
            Orientation = orientation;
            if (Orientation == PageOrientation.Horizontal)
            {
                App.ScaleFontSizes("Landscape");
            }
            else
            {
                App.ScaleFontSizes("Portrait");
            }
            if (currentPage is OrientationContentPage && (currentPage is OnboardLandscape || currentPage is Onboard))
            {
                if (Orientation == PageOrientation.Horizontal)
                {
                    //Application.Current.MainPage = new OnboardLandscape(OrientationContentPage.firstPageLoad);

                    Application.Current.MainPage = new OnboardLandscape(isFirstLoad: OrientationContentPage.firstPageLoad, boardPosition: OrientationContentPage.onboardPosition);
                }
                else
                {
                    //Application.Current.MainPage = App.OnboardScreens;
                    Application.Current.MainPage = new Onboard(OrientationContentPage.firstPageLoad, OrientationContentPage.onboardPosition);
                }
            }
        }

        public PageOrientation Orientation { get; }
    }
    public enum PageOrientation
    {
        Horizontal = 0,
        Vertical = 1,
    }
}
