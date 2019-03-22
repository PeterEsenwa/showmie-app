using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Showmie.Droid;
using Showmie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ShadowedImage), typeof(ShadowedImageRenderer))]
namespace Showmie.Droid
{
    class ShadowedImageRenderer : ImageRenderer
    {
        private ShadowedImage _myImage;
        private ImageView _androidImage;
        private Context ctx;
        private IViewParent parent;

        //private AppCompatButton _androidButton;
        public ShadowedImageRenderer(Context context) : base(context)
        {
            ctx = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                _myImage = e.OldElement as ShadowedImage;
            if (e.NewElement != null)
                _myImage = e.NewElement as ShadowedImage;
            if (Element != null)
                _myImage = Element as ShadowedImage;

            if (Control != null)
            {
                _androidImage = Control;
            }
            else
            {
                _androidImage = CreateNativeControl();
                SetNativeControl(_androidImage);
            }

            _androidImage.Elevation = _myImage.Elevation;
            parent = _androidImage.Parent;
            //_androidImage.RemoveFromParent();

            //CardView card = new CardView(ctx);
            //card.AddView(_androidImage);
        }
    }
}