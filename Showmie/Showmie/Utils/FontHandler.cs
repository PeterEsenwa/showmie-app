namespace Showmie.Utils
{
    class FontHandler
    {
        public static void AdjustFontSizes(double difference)
        {
            double oldLargeFS = (double)Xamarin.Forms.Application.Current.Resources["FontSizeLarge"];
            double oldMediumFS = (double)Xamarin.Forms.Application.Current.Resources["FontSizeMedium"];
            double oldMediumAltFS = (double)Xamarin.Forms.Application.Current.Resources["FontSizeMediumAlt"];
            double oldBigFS = (double)Xamarin.Forms.Application.Current.Resources["FontSizeBig"];
            double oldSmallFS = (double)Xamarin.Forms.Application.Current.Resources["FontSizeSmall"];
            double oldTinyFS = (double)Xamarin.Forms.Application.Current.Resources["FontSizeTiny"];
            Xamarin.Forms.Application.Current.Resources["FontSizeLarge"] = oldLargeFS * difference;
            Xamarin.Forms.Application.Current.Resources["FontSizeMedium"] = oldMediumFS * difference;
            Xamarin.Forms.Application.Current.Resources["FontSizeMediumAlt"] = oldMediumAltFS * difference;
            Xamarin.Forms.Application.Current.Resources["FontSizeBig"] = oldBigFS * difference;
            Xamarin.Forms.Application.Current.Resources["FontSizeSmall"] = oldSmallFS * difference;
            Xamarin.Forms.Application.Current.Resources["FontSizeTiny"] = oldTinyFS * difference;
        }
    }
}
