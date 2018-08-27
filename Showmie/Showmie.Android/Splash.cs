
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Showmie.Droid
{
    [Activity(Label = "Showmie", Icon = "@mipmap/icon", Theme = "@style/Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class Splash : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate( Bundle savedInstanceState )
        {
            base.OnCreate(savedInstanceState);
        }
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            //LoadApplication(new App());
        }
    }
}