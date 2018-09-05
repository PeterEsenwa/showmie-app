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
            if (currentPage is OrientationContentPage && (currentPage is OnboardLandscape || currentPage is Onboard))
            {
                if (Orientation == PageOrientation.Horizontal)
                {
                    Application.Current.MainPage = App.OnboardScreensLandscape;
                }
                else
                {
                    Application.Current.MainPage = App.OnboardScreens;
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
