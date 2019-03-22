using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Utils
{
    class ResponsiveDouble : IMarkupExtension<double>
    {
        public NamedSize Size { get; set; }

        public double Value { get; set; } = 0;

        public double ProvideValue(IServiceProvider serviceProvider)
        {
            if (!Value.Equals(0))
            {
                double uniformDouble = (Value / 14) * Device.GetNamedSize(Size, typeof(Label));
                return Value;
            }
            return 0;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<Double>).ProvideValue(serviceProvider);
        }
    }

    class ResponsiveInteger: IMarkupExtension<int>
    {
        public NamedSize Size { get; set; }

        public int Value { get; set; } = 0;

        public int ProvideValue(IServiceProvider serviceProvider)
        {
            if (!Value.Equals(0))
            {
                int uniformDouble = (int) (Value / 14 * Device.GetNamedSize(Size, typeof(Label)));
                return Value;
            }
            return 0;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return (this as IMarkupExtension<int>).ProvideValue(serviceProvider);
        }
    }
}
