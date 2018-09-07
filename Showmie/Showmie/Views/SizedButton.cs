using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Views
{
    class SizedButton : Button
    {
        public double Padding {
            get { return (double)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }
        public static BindableProperty PaddingProperty { get; } = BindableProperty.Create(
          "Padding",
          typeof(double),
          typeof(SizedButton),
          8,
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              ((SizedButton)bindable).Text = ((SwitchButton)bindable).LeftText;
              ((SizedButton)bindable).InvalidateMeasure();
          });
        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            SizeRequest sizeRequest = Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            sizeRequest = new SizeRequest(new Size(sizeRequest.Request.Width + Padding, sizeRequest.Request.Height));
            return sizeRequest;
        }
 
    }
}
