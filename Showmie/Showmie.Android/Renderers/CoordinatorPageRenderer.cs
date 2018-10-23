using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CoordinatorPage), typeof(CoordinatorPageRenderer))]
namespace Showmie.Droid.Renderers
{
    class CoordinatorPageRenderer : ViewRenderer<CoordinatorPage, CoordinatorLayout>
    {
        private Context ctx;
        private CoordinatorPage _XamCoordinator;
        private CoordinatorLayout _androidCoordinatorLayout;
        private LinearLayout LinearLayout;

        public CoordinatorPageRenderer(Context context) : base(context)
        {
            ctx = Context;
            _androidCoordinatorLayout = new CoordinatorLayout(context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CoordinatorPage> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                _XamCoordinator = e.OldElement as CoordinatorPage;
            if (e.NewElement != null)
                _XamCoordinator = e.NewElement as CoordinatorPage;
            if (Element != null)
                _XamCoordinator = Element as CoordinatorPage;

            if (Control == null)
            {
                SetNativeControl(_androidCoordinatorLayout);
            }

            LinearLayout = new LinearLayout(ctx);
            LinearLayout.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent, 1f);

            foreach (Models.FilterItem item in CoordinatorPage.FilterItems)
            {
                CheckBox _androidCheckBox = new CheckBox(Context)
                {
                    Checked = item.IsChecked,
                    Text = item.Title
                };
                int[][] states = new int[][] {
                    new int[] { Android.Resource.Attribute.StateChecked}, // enabled
                    new int[] { Android.Resource.Attribute.StateEnabled}// pressed
                };

                int[] colors = new int[] {
                    item.CheckedBackgroundColor.ToAndroid(),
                    item.UnCheckedBackgroundColor.ToAndroid()
                };
                _androidCheckBox.ButtonTintList = new ColorStateList(states, colors);
                LinearLayout.AddView(_androidCheckBox);
            }

            //_androidCoordinatorLayout.SetBackgroundColor(Android.Graphics.Color.Green);
            (_androidCoordinatorLayout).AddView(LinearLayout);
        }
    }
}