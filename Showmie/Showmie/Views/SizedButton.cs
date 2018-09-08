using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Views
{
    class SizedButton : Button
    {
        public string Padding {
            get { return (string)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
        public static BindableProperty PaddingProperty { get; } = BindableProperty.Create(
          "Padding",
          typeof(string),
          typeof(SizedButton),
          "8",
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              ((SizedButton)bindable).InvalidateMeasure();
          });
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            SizeRequest sizeRequest = Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            sizeRequest = new SizeRequest(new Size(width: sizeRequest.Request.Width + int.Parse(Padding), height: sizeRequest.Request.Height));
            return sizeRequest;
        }
 
    }
}
