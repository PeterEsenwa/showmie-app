using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace Showmie.Droid
{
    [Activity(Label = "Showmie", Icon = "@mipmap/icon", Theme = "@style/Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class Splash : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
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