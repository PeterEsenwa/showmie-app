using Showmie.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthFunctions))]
namespace Showmie.Droid.DependencyServices
{
    public class FirebaseAuthFunctions : IFirebaseAuthFunctions
    {
        public FirebaseAuthFunctions()
        {

        }
        /// <summary>
        /// Do phone number authentication with firebase, by broadcasting a message to a listening activity to handle the firebase auth
        /// </summary>
        /// <param name="phoneNumber">phone number to authenticate</param>
        /// <returns>Returns authentication result status</returns>
        public bool AuthenticatePhone(string phoneNumber)
        {
            MessagingCenter.Send(this, "AuthenticatePhone", phoneNumber);
            return false;
        }
    }
}