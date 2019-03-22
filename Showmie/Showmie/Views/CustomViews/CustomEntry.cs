using Xamarin.Forms;

namespace Showmie.Views
{
    public class CustomEntry : Entry
    {
        private static BindableProperty MaskProperty { get; } = BindableProperty.Create(
           "Mask",
           typeof(string),
           typeof(CustomEntry),
           null,
           propertyChanged: null);

        public string Mask {
            get { return (string)GetValue(MaskProperty); }
            set { SetValue(MaskProperty, value); }
        }

        private static BindableProperty IsNameProperty { get; } = BindableProperty.Create(
          "IsName",
          typeof(bool),
          typeof(CustomEntry),
          false,
          propertyChanged: null);

        public bool IsName {
            get { return (bool)GetValue(IsNameProperty); }
            set { SetValue(IsNameProperty, value); }
        }


        private static BindableProperty FontSizeFactorProperty { get; } = BindableProperty.Create(
          "FontSizeFactor",
          typeof(double),
          typeof(CustomEntry),
          1.0,
          propertyChanged: OnFontSizeFactorChanged);

        public double FontSizeFactor {
            get { return (double)GetValue(FontSizeFactorProperty); }
            set { SetValue(FontSizeFactorProperty, value); }
        }

        private static void OnFontSizeFactorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomEntry)bindable).OnFontSizeChangedImpl();
        }

        private static BindableProperty NamedFontSizeProperty { get; } = BindableProperty.Create(
          "NamedFontSize",
          typeof(NamedSize),
          typeof(CustomEntry),
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
            ((CustomEntry)bindable).OnFontSizeChangedImpl();
        }


        public virtual void OnFontSizeChangedImpl()
        {
            double namedFontSize = Device.GetNamedSize(NamedFontSize, typeof(Entry));
            FontSize = FontSizeFactor * namedFontSize;
            InvalidateMeasure();
        }
    }

    public class CustomDatePicker : DatePicker
    {
        private static BindableProperty FontSizeFactorProperty { get; } = BindableProperty.Create(
         "FontSizeFactor",
         typeof(double),
         typeof(CustomDatePicker),
         1.0,
         propertyChanged: OnFontSizeFactorChanged);

        public double FontSizeFactor {
            get { return (double)GetValue(FontSizeFactorProperty); }
            set { SetValue(FontSizeFactorProperty, value); }
        }

        private static void OnFontSizeFactorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomDatePicker)bindable).OnFontSizeChangedImpl();
        }

        private static BindableProperty NamedFontSizeProperty { get; } = BindableProperty.Create(
          "NamedFontSize",
          typeof(NamedSize),
          typeof(CustomDatePicker),
          defaultValue: NamedSize.Large,
          propertyChanged: OnNamedFontSizeChanged);

        public NamedSize NamedFontSize {
            get { return (NamedSize)GetValue(NamedFontSizeProperty); }
            set { SetValue(NamedFontSizeProperty, value); }
        }

        private static void OnNamedFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomDatePicker)bindable).OnFontSizeChangedImpl();
        }

        public virtual void OnFontSizeChangedImpl()
        {
            //double w = App.ScreenWidth;
            //double h = App.ScreenHeight;
            //ScreenMetrics metrics = DeviceDisplay.ScreenMetrics;
            //double density = metrics.Density;

            double namedFontSize = Device.GetNamedSize(NamedFontSize, typeof(DatePicker));
            FontSize = FontSizeFactor * namedFontSize;
            InvalidateMeasure();
        }
    }


    public class CustomPicker : Picker
    {
        private static BindableProperty FontSizeFactorProperty { get; } = BindableProperty.Create(
         "FontSizeFactor",
         typeof(double),
         typeof(CustomPicker),
         1.0,
         propertyChanged: OnFontSizeFactorChanged);

        public double FontSizeFactor {
            get { return (double)GetValue(FontSizeFactorProperty); }
            set { SetValue(FontSizeFactorProperty, value); }
        }

        private static void OnFontSizeFactorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomPicker)bindable).OnFontSizeChangedImpl();
        }

        private static BindableProperty NamedFontSizeProperty { get; } = BindableProperty.Create(
          "NamedFontSize",
          typeof(NamedSize),
          typeof(CustomPicker),
          defaultValue: NamedSize.Large,
          propertyChanged: OnNamedFontSizeChanged);

        public NamedSize NamedFontSize {
            get { return (NamedSize)GetValue(NamedFontSizeProperty); }
            set { SetValue(NamedFontSizeProperty, value); }
        }

        private static void OnNamedFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CustomPicker)bindable).OnFontSizeChangedImpl();
        }

        public virtual void OnFontSizeChangedImpl()
        {
            double namedFontSize = Device.GetNamedSize(NamedFontSize, typeof(Picker));
            FontSize = FontSizeFactor * namedFontSize;
            InvalidateMeasure();
        }
    }
}
