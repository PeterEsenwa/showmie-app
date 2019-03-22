using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Showmie.Views.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Firebase;
using Firebase.Auth;
using Showmie.Droid.DependencyServices;
using Showmie.Droid.Utilities;
using Java.Util.Concurrent;
using System;
using FragmentTransaction = Android.Support.V4.App.FragmentTransaction;

namespace Showmie.Droid
{
    [Activity(Label = "PreApp", Icon = "@mipmap/icon", Theme = "@style/PreAppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class PreApp : FormsAppCompatActivity
    {
        #region Declerations
        public static PreApp activity;
        private readonly string[] PermissionsStorage =
        {
          Manifest.Permission.ReadExternalStorage,
          Manifest.Permission.WriteExternalStorage
        };
        private readonly string[] PermissionsLocation =
        {
          Manifest.Permission.AccessCoarseLocation,
          Manifest.Permission.AccessFineLocation
        };
        private readonly int RequestLocationId = 4;
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetNavigationBarColor(Color.White.ToAndroid());
            }
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetNavigationBarColor(Color.White.ToAndroid());
            }
            base.OnCreate(savedInstanceState);
            //activity = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.SetFlags("CollectionView_Experimental");
            Forms.Init(this, savedInstanceState);
            MessagingCenter.Subscribe<SignupPage>(this, "showingSocialOptions", (sender) =>
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    Window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#191919"));
                    Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                }
            });

            MessagingCenter.Subscribe<ContinueSignup>(this, "RequestLocation", (sender) =>
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
                {
                    string lastPermission = "";
                    foreach (string permission in PermissionsLocation)
                    {
                        if (ContextCompat.CheckSelfPermission(this, permission) != (int)Permission.Granted)
                        {
                            if (ActivityCompat.ShouldShowRequestPermissionRationale(this, lastPermission))
                            {
                                Android.Views.View layout = FindViewById(Android.Resource.Id.Content);
                                Snackbar
                                    .Make(layout, "Allow location access or manually select your preferred Country and State", Snackbar.LengthLong)
                                    .SetAction("OK", v => ActivityCompat.RequestPermissions(this, PermissionsLocation, RequestLocationId))
                                    .Show();
                            }
                            else
                            {
                                ActivityCompat.RequestPermissions(this, PermissionsLocation, RequestLocationId);
                            }
                            break;
                        }
                    }
                }
            });

            //InitFirebaseAuth();
            App app = new App();
            LoadApplication(app);
        }


        protected override void OnStop()
        {
            base.OnStop();
        }

        //private void InitFirebaseAuth()
        //{
        //    var options = new FirebaseOptions.Builder()
        //         .SetApiKey("AIzaSyDqm5sLTO9gwN9Pl16WkIDfgQwBExpXPy4")
        //         .SetApplicationId("1:55071138488:android:9d1158b0afb907b1")
        //         .Build();

        //    App = FirebaseApp.Instance;
        //    if (App == null) App = FirebaseApp.InitializeApp(this, options);
        //    Auth = FirebaseAuth.GetInstance(App);

        //}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                foreach (Permission result in grantResults)
                {
                    if (result != Permission.Granted)
                    {
                        Android.Views.View layout = FindViewById(Android.Resource.Id.Content);
                        Snackbar
                            .Make(layout, "Manually select your preferred Country and State", Snackbar.LengthLong)
                            .SetAction("OK", v => { })
                            .Show();
                        break;
                    }
                }
            }
            else
            {
                Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }

        }

      
    }
}