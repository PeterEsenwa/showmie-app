
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Showmie.Droid
{
    [Activity(Label = "PreApp", Icon = "@mipmap/icon", Theme = "@style/PreAppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class PreApp : FormsAppCompatActivity
    {
        public static PreApp activity;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                // Kill status bar underlay added by FormsAppCompatActivity
                // Must be done before calling FormsAppCompatActivity.OnCreate()
                var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (statusBarHeightInfo == null)
                {
                    statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                }
                statusBarHeightInfo?.SetValue(this, 0);
            }
            base.OnCreate(savedInstanceState);
            activity = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);

            App app = new App();
            LoadApplication(app);
        }

        protected override void OnStop()
        {
            Xamarin.Forms.Application.Current.Properties["current_page"] = null;
            base.OnStop();
        }
    }
}