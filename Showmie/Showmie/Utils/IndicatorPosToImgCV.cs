using System;
using System.Globalization;
using Xamarin.Forms;

namespace Showmie.Utils
{
    internal class IndicatorPosToImgCV : IValueConverter
    {
        public int Index { get; set; }

        public IndicatorPosToImgCV()
        {

        }

        public string ChooseImagePath(object currentPosition, object Index)
        {
            int curPos = System.Convert.ToInt32(currentPosition);
            int index = System.Convert.ToInt32(Index);
            if (index.Equals(curPos))
            {
                return "current_page_indicator.png";
            }
            else if (!index.Equals(curPos))
            {
                return "other_page_indicator.png";
            }
            return "";
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(int))
            {
                return ChooseImagePath(value, parameter);
            }
            return "Unknwown";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "current_page_indicator.png")
            {
                return Index;
            }
            else
            {
                return -1;
            }
        }

    }
}
