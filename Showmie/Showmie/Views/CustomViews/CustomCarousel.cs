using System;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    internal class CustomCarousel : CarouselView
    {
        public event EventHandler<int> PositionChanged;

        public void PositionChanger(int newPosition)
        {
            PositionChanged?.Invoke(this, newPosition);
        }

        public CustomCarousel() : base()
        {
        }
    }
}
