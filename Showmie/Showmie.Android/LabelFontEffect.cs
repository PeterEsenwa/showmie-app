using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Showmie.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Showmie")]
[assembly: ExportEffect(typeof(LabelFontEffect), "LabelFontEffect")]
namespace Showmie.Droid
{
    class LabelFontEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            throw new NotImplementedException();
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}