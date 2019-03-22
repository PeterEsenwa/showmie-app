using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Support.Design.Widget;
using Android.Views.InputMethods;
using Android.Widget;
using Showmie.Droid.Renderers;
using Showmie.Views;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Showmie.Droid.Renderers
{
    internal class CustomEntryRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<CustomEntry, TextInputLayout>
    {
        private TextInputLayout inputLayout;
        private EditText editText;
        private CustomEntry customEntry;
        private string _mask = "";
        public string Mask {
            get => _mask;
            set {
                _mask = value;
                SetPositions();
            }
        }

        public CustomEntryRenderer(Context context) : base(context)
        {
            inputLayout = new TextInputLayout(context);
            editText = new EditText(context) { };
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomEntry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                customEntry = e.OldElement as CustomEntry;
            }
            if (e.NewElement != null)
            {
                customEntry = e.NewElement as CustomEntry;
            }
            if (Element != null)
            {
                customEntry = Element as CustomEntry;
            }

            if (Control == null)
            {
                int[][] states = new int[][]
                {
                    new int[] { Android.Resource.Attribute.StateFocused }, // enabled
                    new int[] {-Android.Resource.Attribute.StateFocused}, // disabled
                    new int[] {-Android.Resource.Attribute.StateEnabled}, // unchecked
                    new int[] { Android.Resource.Attribute.StateEnabled }  // pressed
                };

                int[] colors = new int[]
                {
                    customEntry.TextColor.ToAndroid(),
                    customEntry.PlaceholderColor.ToAndroid(),
                    customEntry.PlaceholderColor.ToAndroid(),
                    customEntry.PlaceholderColor.ToAndroid()
                };

                editText.Hint = customEntry.Placeholder;
                editText.SetHintTextColor(customEntry.PlaceholderColor.ToAndroid());
                ColorStateList stateColors = new ColorStateList(states, colors);

                editText.SetMaxLines(1);
                editText.SetTextColor(stateColors);

                ////editText.Typeface = 
                SetNativeControl(inputLayout);
                SetInputType();
                SetImeAction();
                editText.TextChanged += EditText_TextChanged;
                if (customEntry.FontFamily.Contains(".ttf"))
                {
                    int ttfPosition = customEntry.FontFamily.LastIndexOf(".ttf") + 4;
                    string fontFamily = customEntry.FontFamily.Substring(0, ttfPosition);
                    editText.Typeface = Typeface.CreateFromAsset(Context.Assets, fontFamily);
                    Control.Typeface = Typeface.CreateFromAsset(Context.Assets, fontFamily);
                }

                Control.AddView(editText);

            }
        }

        private void SetInputType()
        {
            if (customEntry.IsPassword)
            {
                Control.PasswordVisibilityToggleEnabled = true;
                editText.LongClickable = false;
                editText.InputType = Android.Text.InputTypes.TextVariationPassword | Android.Text.InputTypes.TextFlagNoSuggestions;
                editText.TransformationMethod = new Android.Text.Method.PasswordTransformationMethod();
            }
            else if (customEntry.IsName)
            {
                editText.InputType = Android.Text.InputTypes.TextVariationPersonName
                    | Android.Text.InputTypes.TextFlagCapWords;
            }
            else if (customEntry.Keyboard == Keyboard.Email)
            {
                editText.InputType = Android.Text.InputTypes.TextVariationEmailAddress | Android.Text.InputTypes.TextVariationWebEmailAddress;
            }
            else if (customEntry.Keyboard == Keyboard.Telephone)
            {
                editText.InputType = Android.Text.InputTypes.ClassPhone;
                editText.TextChanged += OnEntryTextChanged;
                this.Mask = customEntry.Mask;
            }
            else
            {
                editText.InputType = Android.Text.InputTypes.TextVariationPersonName;
            }
        }

        private void SetImeAction()
        {
            if (customEntry.ReturnType == ReturnType.Next)
            {
                editText.ImeOptions = ImeAction.Next;
                editText.EditorAction += EditText_NextAction;
            }
            if (customEntry.ReturnType == ReturnType.Go)
            {
                editText.ImeOptions = ImeAction.Go;
            }
            if (customEntry.ReturnType == ReturnType.Done)
            {
                editText.ImeOptions = ImeAction.Done;
            }
            if (customEntry.ReturnType == ReturnType.Search)
            {
                editText.ImeOptions = ImeAction.Search;
            }
            if (customEntry.ReturnType == ReturnType.Send)
            {
                editText.ImeOptions = ImeAction.Send;
            }
            if (customEntry.ReturnType == ReturnType.Default)
            {
                editText.ImeOptions = ImeAction.Unspecified;
            }
        }

        private void EditText_NextAction(object sender, TextView.EditorActionEventArgs e)
        {
            e.Handled = false;
            if (e.ActionId == ImeAction.Next)
            {
                EditText curEdittext = (EditText)sender;
                MessagingCenter.Send(customEntry, "unfocus");
                e.Handled = true;
            }
        }

        private void EditText_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            customEntry.Text = ((EditText)sender).Text;
        }

        private IDictionary<int, char> _positions;

        private void SetPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                _positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (Mask[i] != 'X')
                    list.Add(i, Mask[i]);

            _positions = list;
        }

        private void OnEntryTextChanged(object sender, Android.Text.TextChangedEventArgs args)
        {
            var entry = sender as EditText;

            var text = entry.Text;

            if (string.IsNullOrWhiteSpace(text) || _positions == null)
                return;

            if (text.Length > _mask.Length)
            {
                entry.Text = text.Remove(text.Length - 1);
                return;
            }

            foreach (var position in _positions)
                if (text.Length >= position.Key + 1)
                {
                    var value = position.Value.ToString();
                    if (text.Substring(position.Key, 1) != value)
                        text = text.Insert(position.Key, value);
                }

            if (entry.Text != text)
            {
                entry.Text = text;
                entry.SetSelection(entry.Text.Length);
            }

        }

    }
}