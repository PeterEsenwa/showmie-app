using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views.CustomViews;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ExploreCardHolder), typeof(ExploreCardHolderRenderer))]

namespace Showmie.Droid.Renderers
{
    class ExploreCardHolderRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<ExploreCardHolder, CardView>
    {
        //private Context ctx;
        private CardView cardView;
        private ExploreCardHolder exploreCardHolder;

        public ExploreCardHolderRenderer(Context context) : base(context)
        {

        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ExploreCardHolder> e)
        {
            base.OnElementChanged(e);

            int height = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 55, Resources.DisplayMetrics);
            int width = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 64, Resources.DisplayMetrics);
            if (Control == null)
            {
                cardView = new CardView(Context) { LayoutParameters = new LayoutParams(width: width, height: height) };
                SetNativeControl(cardView);
            }
            else
            {
                cardView.LayoutParameters.Height = height;
                cardView.LayoutParameters.Width = width;
            }

            if (e.OldElement != null)
            {
                exploreCardHolder = e.OldElement as ExploreCardHolder;
            }
            if (e.NewElement != null)
            {
                exploreCardHolder = e.NewElement as ExploreCardHolder;
            }
            if (Element != null)
            {
                exploreCardHolder = Element as ExploreCardHolder;
            }

            int horizontal = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 12, Resources.DisplayMetrics);
            int vertical = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 8, Resources.DisplayMetrics);
            int radius = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
            int minheight = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 42, Resources.DisplayMetrics);

            cardView.SetBackgroundColor(exploreCardHolder.BackgroundColor.ToAndroid());
            cardView.SetMinimumHeight(minheight);
            cardView.SetMinimumWidth(minheight);
            
            cardView.SetPadding(horizontal, vertical, horizontal, vertical);
            cardView.Radius = radius;

        }
    }
}