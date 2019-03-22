using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Utils
{
    class MyServices
    {
        protected HttpClient httpClient = new HttpClient
        {
            MaxResponseContentBufferSize = 500000,
            Timeout = TimeSpan.FromSeconds(30)
        };
        protected JToken body;
        protected JToken error;
    }

    public class NegateBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}