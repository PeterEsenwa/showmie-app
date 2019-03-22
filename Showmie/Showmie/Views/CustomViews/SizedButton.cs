using Xamarin.Forms;

namespace Showmie.Views
{
    public class ShadowedImage : Image
    {
        public float Elevation {
            get { return (float)GetValue(ElevationProperty); }
            set { SetValue(ElevationProperty, value); }
        }

        private static BindableProperty ElevationProperty { get; } = BindableProperty.Create(
          "Elevation",
          typeof(float),
          typeof(SizedButton),
          float.Parse("5"),
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              ((Image)bindable).Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);
          });
    }

    internal class SizedButton : Button
    {
        public int Elevation {
            get { return (int)GetValue(ElevationProperty); }
            set { SetValue(ElevationProperty, value); }
        }

        private static BindableProperty ElevationProperty { get; } = BindableProperty.Create(
          "Elevation",
          typeof(int),
          typeof(SizedButton),
          int.Parse("4"),
          propertyChanged: null);

        private static BindableProperty CapitalizeProperty { get; } = BindableProperty.Create(
         "Capitalize",
         typeof(bool),
         typeof(SizedButton),
         false,
         propertyChanged: null);

        public bool Capitalize {
            get { return (bool)GetValue(CapitalizeProperty); }
            set { SetValue(CapitalizeProperty, value); }
        }
    }
}
