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

        public Thickness Padding {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        private static BindableProperty PaddingProperty { get; } = BindableProperty.Create(
          "Padding",
          typeof(Thickness),
          typeof(SizedButton),
          new Thickness(5),
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              ((SizedButton)bindable).InvalidateMeasure();
          });
    }
}
