
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Xamarin.Forms;

namespace Showmie.Droid
{
    [Activity(Label = "PreApp", Icon = "@mipmap/icon", Theme = "@style/PreAppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class PreApp : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            App app = new App();
            LoadApplication(app);
            //DisplayMetrics dm = new DisplayMetrics();
            //IWindowManager windowManager = this.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            //windowManager.DefaultDisplay.GetRealMetrics(dm);
            //int width = dm.WidthPixels;
            //int height = dm.HeightPixels;
            //windowManager.DefaultDisplay.GetMetrics(dm);
            //width = dm.WidthPixels;
            //height = dm.HeightPixels;
            //App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            //App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);
        }

        protected override void OnStop()
        {
            Xamarin.Forms.Application.Current.Properties["current_page"] = null;
            base.OnStop();
        }
    }
}