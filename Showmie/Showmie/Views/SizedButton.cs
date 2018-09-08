using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Views
{
    class SizedButton : Button
    {
        public Thickness Padding {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
        public static BindableProperty PaddingProperty { get; } = BindableProperty.Create(
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
