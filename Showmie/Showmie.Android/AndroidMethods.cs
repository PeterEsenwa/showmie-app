using Showmie.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidMethods))]
namespace Showmie.Droid
{
    public class AndroidMethods : IAndroidMethods
    {
        public void CloseApp()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
    }
}