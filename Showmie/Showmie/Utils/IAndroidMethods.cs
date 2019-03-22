using Android.Content;

namespace Showmie
{
    public interface IAndroidMethods
    {
        void HideBar();
        void ShowBar();
        void SetActionBarIcon();
    }

    /**
     */
    internal interface IFirebaseAuthFunctions
    {
        bool AuthenticatePhone(string phoneNumber);
    }
}