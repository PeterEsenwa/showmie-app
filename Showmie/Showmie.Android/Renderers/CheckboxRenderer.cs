using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AColor = Android.Graphics.Color;
using XColor = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(CustomCheckbox), typeof(CheckboxRenderer))]
namespace Showmie.Droid.Renderers
{
    internal class CheckboxRenderer : ViewRenderer<CustomCheckbox, CheckBox>
    {
        private CheckBox _androidCheckBox;
        private CustomCheckbox _customCheckbox;

        public CheckboxRenderer(Context context) : base(context)
        {

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
                _customCheckbox = e.OldElement as CustomCheckbox;
                CheckboxHolder parent = _customCheckbox.Parent as CheckboxHolder;
                _customCheckbox.PropertyChanged -= parent._customCheckbox_PropertyChanged;
                _customCheckbox.PropertyChanged -= _customCheckbox_PropertyChanged;
                _androidCheckBox.CheckedChange -= _customCheckbox.CheckedChange;
            }
            if (e.NewElement != null)
            {
                _customCheckbox = e.NewElement as CustomCheckbox;
                CheckboxHolder parent = _customCheckbox.Parent as CheckboxHolder;
                _customCheckbox.PropertyChanged += parent._customCheckbox_PropertyChanged;
                _customCheckbox.PropertyChanged += _customCheckbox_PropertyChanged;
                _androidCheckBox.CheckedChange += _customCheckbox.CheckedChange;
            }
            if (Element != null)
                _customCheckbox = Element as CustomCheckbox;

            _androidCheckBox.Checked = _customCheckbox.IsChecked;
            _androidCheckBox.Text = _customCheckbox.Label;

            _androidCheckBox.SetTextColor(new ColorStateList(
                new int[][] {
                    new int[] { Android.Resource.Attribute.StateChecked},
                    new int[] { Android.Resource.Attribute.StateEnabled}
                },
                new int[] {
                    _customCheckbox.LabelColor.ToAndroid(),
                    ((XColor)Application.Current.Resources["TextColorLighterGrey"] ).ToAndroid(AColor.ParseColor("#8C8C8C"), Context)
                }));

            _androidCheckBox.SetTextSize(Android.Util.ComplexUnitType.Sp, _customCheckbox.TextSize);

            if (_customCheckbox.FontFamily.Contains(".ttf"))
            {
                _androidCheckBox.Typeface = Typeface.CreateFromAsset(Context.Assets, _customCheckbox.FontFamily.Substring(0, _customCheckbox.FontFamily.LastIndexOf(".ttf") + 4));
            }

            _androidCheckBox.ButtonTintList = new ColorStateList(
                new int[][] {
                    new int[] { Android.Resource.Attribute.StateChecked},
                    new int[] { Android.Resource.Attribute.StateEnabled}
                },
                new int[] {
                    _customCheckbox.CheckedBackgroundColor.ToAndroid(),
                    _customCheckbox.UnCheckedBackgroundColor.ToAndroid()
                });

        }

        private void _customCheckbox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                _androidCheckBox.Checked = _customCheckbox.IsChecked;
            }
        }
    }
}