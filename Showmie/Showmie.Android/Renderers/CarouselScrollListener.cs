using Android.Support.V7.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views.CustomViews;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(CustomCarousel), typeof(CustomCarouselRenderer))]
namespace Showmie.Droid.Renderers
{
    internal partial class CustomCarouselRenderer
    {
        internal class CarouselScrollListener : OnScrollListener
        {
            private readonly CustomCarouselRenderer customCarouselRenderer;

            public CarouselScrollListener(CustomCarouselRenderer customCarouselRenderer)
            {
                this.customCarouselRenderer = customCarouselRenderer;
            }

            public override void OnScrollStateChanged(RecyclerView recyclerView, int newState)
            {
                base.OnScrollStateChanged(recyclerView, newState);

                if (customCarouselRenderer.Element != null)
                {
                    if (newState == 0)
                    {
                        if (recyclerView.GetLayoutManager() is LinearLayoutManager)
                        {
                            int visiblePosition = (recyclerView.GetLayoutManager() as LinearLayoutManager).FindFirstVisibleItemPosition();
                            (customCarouselRenderer.Element as CustomCarousel).PositionChanger(visiblePosition);
                        }
                        else if (recyclerView.GetLayoutManager() is GridLayoutManager)
                        {
                            int visiblePosition = (recyclerView.GetLayoutManager() as GridLayoutManager).FindFirstVisibleItemPosition();
                            (customCarouselRenderer.Element as CustomCarousel).PositionChanger(visiblePosition);
                        }
                    } 
                }
            }
        }

    }
}