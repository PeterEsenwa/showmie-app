using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Showmie.Droid;
using static Showmie.Droid.PreApp;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Showmie.Droid
{
    public class AndroidMethods : IAndroidMethods
    {
        Window window = activity.Window;
        public void HideBar()
        {
            //Intent main = new Intent(Intent.ActionMain);
            //main.AddCategory(Intent.CategoryHome);
            //main.SetFlags(ActivityFlags.NewTask);
            //context.StartActivity(main);
            //var activity = (Activity)Application.Context;
            window.AddFlags(WindowManagerFlags.Fullscreen | WindowManagerFlags.TurnScreenOn);
            window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
        }

        public void ShowBar()
        {
            window.AddFlags(WindowManagerFlags.ForceNotFullscreen);
            window.ClearFlags(WindowManagerFlags.Fullscreen);
        }

        public void SetActionBarIcon()
        {
            

        }
    }
}