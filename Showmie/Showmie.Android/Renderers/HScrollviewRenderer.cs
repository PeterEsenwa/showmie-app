using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HScrollview), typeof(HScrollviewRenderer))]
namespace Showmie.Droid.Renderers
{
    public class HScrollviewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement as HScrollview;
            element?.Render();
        }
        public HScrollviewRenderer(Context context) : base(context)
        {
            Context ctx = context;
        }
    }
}