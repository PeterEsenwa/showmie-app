using System;
using System.Collections.Generic;
using System.Text;

namespace Showmie.Utils
{
    class FontHandler
    {
        public static void AdjustFontSizes(double difference)
        {
            double oldLargeFS = (double)Xamarin.Forms.Application.Current.Resources["fontSizeLarge"];
            double oldMediumFS = (double)Xamarin.Forms.Application.Current.Resources["fontSizeMedium"];
            double oldBigFS = (double)Xamarin.Forms.Application.Current.Resources["fontSizeBig"];
            double oldSmallFS = (double)Xamarin.Forms.Application.Current.Resources["fontSizeSmall"];
            double oldTinyFS = (double)Xamarin.Forms.Application.Current.Resources["fontSizeTiny"];
            Xamarin.Forms.Application.Current.Resources["fontSizeLarge"] = oldLargeFS * difference;
            Xamarin.Forms.Application.Current.Resources["fontSizeMedium"] = oldMediumFS * difference;
            Xamarin.Forms.Application.Current.Resources["fontSizeBig"] = oldBigFS * difference;
            Xamarin.Forms.Application.Current.Resources["fontSizeSmall"] = oldSmallFS * difference;
            Xamarin.Forms.Application.Current.Resources["fontSizeTiny"] = oldTinyFS * difference;
        }
    }
}
