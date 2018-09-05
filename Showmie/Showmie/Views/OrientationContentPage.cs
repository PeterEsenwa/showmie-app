using Showmie.Utils;
using System;

using Xamarin.Forms;

namespace Showmie.Views
{
    public class OrientationContentPage : ContentPage
    {
        private static double _width;
        private static double _height;
        internal static bool firstPageLoad = true;

        private event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

        public OrientationContentPage()
            : base()
        {

        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (firstPageLoad == true)
            {
                _width = this.Width;
                _height = this.Height;
                firstPageLoad = false;
                base.OnSizeAllocated(width, height);
                return;
            }
            
            var oldWidth = _width;
            const double sizenotallocated = -1;

            base.OnSizeAllocated(width, height);
            if (_width==width && _height == height) return;

            _width = width;
            _height = height;

            // ignore if the previous height was size unallocated
            if (oldWidth == sizenotallocated) return;
            // Has the device been rotated ?
            OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((width < height) ? PageOrientation.Vertical : PageOrientation.Horizontal, this));
        }

    }
}
