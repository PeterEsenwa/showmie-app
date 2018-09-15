using Xamarin.Forms;

namespace Showmie.Views
{
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
