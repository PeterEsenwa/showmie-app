using Android.Content;
using Showmie.Droid.Renderers;
using Showmie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.Widget;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;

[assembly: ExportRenderer(typeof(SizedButton), typeof(SizedButtonRenderer))]
namespace Showmie.Droid.Renderers
{
    internal class SizedButtonRenderer: ButtonRenderer
    {
        private SizedButton _myButton;
        private AppCompatButton _androidButton;
        public SizedButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                _myButton = e.OldElement as SizedButton;
            if (e.NewElement != null)
                _myButton = e.NewElement as SizedButton;
            if (Element != null)
                _myButton = Element as SizedButton;

            if (Control != null)
            {
                _androidButton = Control;
            }
            else
            {
                _androidButton = CreateNativeControl();
                SetNativeControl(_androidButton);
            }

            if (_myButton != null)
            {
                _androidButton.Elevation = _myButton.Elevation;
                if (!_myButton.Capitalize)
                {
                    _androidButton.SetSupportAllCaps(false);
                }
                if (_myButton.BackgroundColor == Color.Transparent)
                {
                    _androidButton.Background = Context.GetDrawable(Resource.Drawable.abc_btn_borderless_material);
                }
            }
            
        }
    }
}