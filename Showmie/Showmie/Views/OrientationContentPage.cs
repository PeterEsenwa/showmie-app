using Showmie.Utils;
using System;

using Xamarin.Forms;

namespace Showmie.Views
{
    public class OrientationContentPage : ContentPage
    {
        private double _width;
        private double _height;

        private event EventHandler<PageOrientationEventArgs> OnOrientationChanged = (e, a) => { };

        public OrientationContentPage()
            : base()
        {
            Init();
        }

        private void Init()
        {
            _width = this.Width;
            _height = this.Height;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            var oldWidth = _width;
            const double sizenotallocated = -1;

            base.OnSizeAllocated(width, height);
            if (_width==width && _height == height) return;

            _width = width;
            _height = height;

            // ignore if the previous height was size unallocated
            if (oldWidth == sizenotallocated) return;

            // Has the device been rotated ?
            if (width == oldWidth)
                OnOrientationChanged.Invoke(this, new PageOrientationEventArgs((width < height) ? PageOrientation.Vertical : PageOrientation.Horizontal, this));
        }

    }
}
