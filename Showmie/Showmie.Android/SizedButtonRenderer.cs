using Android.Content;
using Showmie.Droid;
using Showmie.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Support.V7.Widget;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;

[assembly: ExportRenderer(typeof(SizedButton), typeof(SizedButtonRenderer))]
namespace Showmie.Droid
{
    class SizedButtonRenderer: ButtonRenderer
    {
        private SizedButton myButton;
        private AppCompatButton androidButton;
        public SizedButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
                myButton = e.OldElement as SizedButton;
            if (e.NewElement != null)
                myButton = e.NewElement as SizedButton;
            if (Element != null)
                myButton = Element as SizedButton;

            if (Control != null)
            {
                androidButton = Control as AppCompatButton;
            }
            else
            {
                androidButton = CreateNativeControl();
                SetNativeControl(androidButton);
            }

            androidButton.SetPadding((int)myButton.Padding.Left, (int)myButton.Padding.Top, (int)myButton.Padding.Right, (int)myButton.Padding.Bottom);
        }
    }
}