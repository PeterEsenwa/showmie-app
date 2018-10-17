using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarRenderer))]
namespace Showmie.Droid.Renderers
{
    class CustomSearchBarRenderer : SearchBarRenderer
    {
        private readonly Context ctx;

        public CustomSearchBarRenderer(Context context) : base(context)
        {
            ctx = context;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
                Control.Background = ContextCompat.GetDrawable(ctx, Resource.Drawable.searchbar_background);
        }
    }
}