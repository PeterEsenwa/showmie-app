using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace Showmie.Droid
{
    [Activity(
            Label = "Showmie",
            Icon = "@mipmap/icon",
            Theme = "@style/Splash",
            MainLauncher = true,
            ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
            ScreenOrientation = ScreenOrientation.Portrait
        )]

    public class Splash : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var m_activity = new Intent(this, typeof(PreApp));
            StartActivity(m_activity);
            Finish();
        }
    }

}