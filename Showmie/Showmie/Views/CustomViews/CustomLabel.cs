using Xamarin.Essentials;
using Xamarin.Forms;

namespace Showmie.Views
{
    internal class CustomLabel : Label
    {

        private static BindableProperty FontSizeFactorProperty { get; } = BindableProperty.Create(
          "FontSizeFactor",
          typeof(double),
          typeof(CustomLabel),
          1.0,
          propertyChanged: OnFontSizeFactorChanged);
        // public static readonly BindableProperty FontSizeFactorProperty =
        //BindableProperty.Create(
        //"FontSizeFactor", typeof(double), typeof(CustomLabel),
        //defaultValue: 1.0, propertyChanged: OnFontSizeFactorChanged);

        public double FontSizeFactor {
            get { return (double)GetValue(FontSizeFactorProperty); }
            set { SetValue(FontSizeFactorProperty, value); }
        }

        private static void OnFontSizeFactorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomLabel)bindable).OnFontSizeChangedImpl();
        }

        private static BindableProperty NamedFontSizeProperty { get; } = BindableProperty.Create(
          "NamedFontSize",
          typeof(NamedSize),
          typeof(CustomLabel),
          defaultValue: NamedSize.Large,
          propertyChanged: OnNamedFontSizeChanged);

        // When work wants to kill you
        // Just remember to...

        public NamedSize NamedFontSize {
            get { return (NamedSize)GetValue(NamedFontSizeProperty); }
            set { SetValue(NamedFontSizeProperty, value); }
        }

        private static void OnNamedFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomLabel)bindable).OnFontSizeChangedImpl();
        }


        public virtual void OnFontSizeChangedImpl()
        {
            //double w = App.ScreenWidth;
            //double h = App.ScreenHeight;
            //ScreenMetrics metrics = DeviceDisplay.ScreenMetrics;
            //double density = metrics.Density;

            double namedFontSize = Device.GetNamedSize(NamedFontSize, typeof(Label));
            FontSize = FontSizeFactor * namedFontSize;
            InvalidateMeasure();
        }

    }
}
