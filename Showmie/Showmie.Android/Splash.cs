using Android;
using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Firebase;
using Firebase.Auth;
using Java.Util.Concurrent;
using Showmie.Droid.DependencyServices;
using Showmie.Droid.Utilities;
using Showmie.Views.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Showmie.Droid.PhoneVerificationDialog;

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

    public class Splash : FormsAppCompatActivity, IOnCompleteListener
    {
        #region Declerations
        /// <summary>
        /// Gets the Storage permissions to check for and request if not granted
        /// </summary>
        private readonly string[] PermissionsStorage =
        {
          Manifest.Permission.ReadExternalStorage,
          Manifest.Permission.WriteExternalStorage
        };

        /// <summary>
        /// Sets the Location permissions to check for and request if not granted
        /// </summary>
        private readonly string[] PermissionsLocation =
        {
          Manifest.Permission.AccessCoarseLocation,
          Manifest.Permission.AccessFineLocation
        };

        /// <summary>
        /// Gets the location request code.
        /// </summary>
        private readonly int RequestLocationId = 4;

        /// <summary>
        /// Gets and sets <see cref="FirebaseApp"/> instance
        /// </summary>
        private FirebaseApp App { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FirebaseAuth"/> instance to be used for authentication operations5
        /// </summary>
        private FirebaseAuth Auth { get; set; }

        /// <summary>
        /// Gets the amount of time usesr has to wait for sms auto-retrieval
        /// </summary>
        private readonly int verificationTimeout = 10;
        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetStatusBarColor(Color.White.ToAndroid());
                Window.SetNavigationBarColor(Color.White.ToAndroid());
            }
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Forms.SetFlags("CollectionView_Experimental");
            Forms.Init(this, savedInstanceState);

            /**
             * Subscribe to the "AuthenticatePhone" message, and start/handle firebase phone authentication
             */
            MessagingCenter.Subscribe<FirebaseAuthFunctions, string>(this, "AuthenticatePhone", (sender, phoneNumber) =>
            {
                var phoneVerificationCallbacks = new PhoneAuthOnVerificationStateChangedCallbacks();
                phoneVerificationCallbacks.CodeSent += PhoneVerificationCodeSent;
                phoneVerificationCallbacks.VerificationCompleted += PhoneVerificationCompleted;
                phoneVerificationCallbacks.VerificationFailed += PhoneVerificationFailed;

                PhoneAuthProvider.GetInstance(Auth).VerifyPhoneNumber(phoneNumber, 30, TimeUnit.Seconds, this, phoneVerificationCallbacks);
            });

            MessagingCenter.Subscribe<SignupPage>(this, "showingSocialOptions", (sender) =>
            {
                InitFirebaseAuth();
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#E81945"));
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

            Window.SetBackgroundDrawable(new ColorDrawable(Color.White.ToAndroid()));

            App app = new App();
            LoadApplication(app);
        }


        private void PhoneVerificationCodeSent(object sender, EventArgs e)
        {
            PhoneVerificationDialog dialog = new PhoneVerificationDialog(verificationTimeout, Auth, (sender as PhoneAuthOnVerificationStateChangedCallbacks).VerificationId);
            var ft = SupportFragmentManager.BeginTransaction();
            dialog.Show(ft, "PhoneVerificationDialog");
        }

        private void PhoneVerificationCompleted(object sender, EventArgs e)
        {

        }

        private void PhoneVerificationFailed(object sender, EventArgs e)
        {

        }
   
        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder()
                 .SetApiKey("AIzaSyDqm5sLTO9gwN9Pl16WkIDfgQwBExpXPy4")
                 .SetApplicationId("1:55071138488:android:9d1158b0afb907b1")
                 .Build();
            App = FirebaseApp.Instance;
            if (App == null) App = FirebaseApp.InitializeApp(this, options);
            Auth = FirebaseAuth.GetInstance(App);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {

            if (grantResults == null)
            {
                System.Diagnostics.Debug.WriteLine("Error: Could not find any permission results", "OnRequestPermissionsResult");
            }
            else
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

        public async void OnComplete(string InputtedCode)
        {
        }
    }

}