using Xamarin.Forms;

namespace Showmie.Views
{
    public class ShadowedImage: Image
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
    }
}
