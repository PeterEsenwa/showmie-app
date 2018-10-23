using Android.Content;
using Android.Content.Res;
using Android.Support.Design.Widget;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomCheckbox), typeof(CheckboxRenderer))]
namespace Showmie.Droid.Renderers
{
    internal class CheckboxRenderer : ViewRenderer<CustomCheckbox, CheckBox>
    {
        private Context ctx;
        private CheckBox _androidCheckBox;
        private CustomCheckbox _customCheckbox;

        public CheckboxRenderer(Context context) : base(context)
        {
            ctx = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckbox> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                _androidCheckBox = new CheckBox(Context);
                SetNativeControl(_androidCheckBox);
            }

            if (e.OldElement != null)
            {
                //_androidCheckBox. -= OnCameraPreviewClicked;
                _customCheckbox = e.OldElement as CustomCheckbox;
            }
            if (e.NewElement != null)
            {
                //Control.Preview = Camera.Open((int)e.NewElement.Camera);
                _customCheckbox = e.NewElement as CustomCheckbox;
                //cameraPreview.Click += OnCameraPreviewClicked;
            }
            if (Element != null)
                _customCheckbox = Element as CustomCheckbox;

            //_androidCheckBox.SetHeight((int)_customCheckbox.Height); 
            //_androidCheckBox.SetWidth((int)_customCheckbox.Width);

            _androidCheckBox.Checked = _customCheckbox.IsChecked;
            _androidCheckBox.Text = _customCheckbox.Label;
            ////_androidCheckBox.Context.The
            //Control.SetBackgroundColor(Android.Graphics.Color.ParseColor("#EBEBEB"));
            //_androidCheckBox.

            int[][] states = new int[][] {
                new int[] { Android.Resource.Attribute.StateChecked}, // enabled
                new int[] { Android.Resource.Attribute.StateEnabled}// pressed
            };

            int[] colors = new int[] {
                _customCheckbox.CheckedBackgroundColor.ToAndroid(),
                _customCheckbox.UnCheckedBackgroundColor.ToAndroid()
            };
            _androidCheckBox.ButtonTintList = new ColorStateList(states, colors);
        }


    }
}