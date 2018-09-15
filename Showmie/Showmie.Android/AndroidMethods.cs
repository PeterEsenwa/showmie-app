using Android.App;
using Android.Content;
using Showmie.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Showmie.Droid
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp(Context context)
        {
            Intent main = new Intent(Intent.ActionMain);
            main.AddCategory(Intent.CategoryHome);
            main.SetFlags(ActivityFlags.NewTask);
            context.StartActivity(main);
            var activity = (Activity)context;
            activity.FinishAffinity();
        }
    }
}