using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    class CustomBottomSheet : View
    {
        private static BindableProperty IsRoundedProperty { get; } = BindableProperty.Create(
         "IsRounded",
         typeof(bool),
         typeof(CustomBottomSheet),
         true,
         propertyChanged: null);

        public bool IsRounded {
            get { return (bool)GetValue(IsRoundedProperty); }
            set { SetValue(IsRoundedProperty, value); }
        }
    }
}
