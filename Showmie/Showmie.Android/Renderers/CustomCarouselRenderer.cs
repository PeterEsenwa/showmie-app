using Android.Content;
using Showmie.Droid.Renderers;
using Showmie.Views.CustomViews;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomCarousel), typeof(CustomCarouselRenderer))]
namespace Showmie.Droid.Renderers
{
    internal partial class CustomCarouselRenderer : CarouselViewRenderer
    {
        public CustomCarouselRenderer(Context context) : base(context)
        { 
            AddOnScrollListener(new CarouselScrollListener(this));
        }
    }
}