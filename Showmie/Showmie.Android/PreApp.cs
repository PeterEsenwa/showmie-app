
using Android.App;
using Android.Content.PM;
using Android.OS;
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
        }
    }
}