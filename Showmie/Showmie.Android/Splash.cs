using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace Showmie.Droid
{
    [Activity(Label = "Showmie", Icon = "@mipmap/icon", Theme = "@style/Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class Splash : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
        }

        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            //LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
     
}