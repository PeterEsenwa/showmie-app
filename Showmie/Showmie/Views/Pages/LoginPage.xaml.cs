using Showmie.Models;
using Showmie.Utils;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private bool keepLogin;

        public LoginPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UserService userService = new UserService();
            User user = new User();
            //if (Application.Current.Properties.ContainsKey("curUsername") && Application.Current.Properties.ContainsKey("curUserpass"))
            //{
            //    loader.IsVisible = true;
            //    loader.IsRunning = true;
            //    intro.IsEnabled = false;

            //    string username = ((string)Application.Current.Properties["curUsername"]).Trim();
            //    string password = ((string)Application.Current.Properties["curUserpass"]).Trim();
            //    var current = Connectivity.NetworkAccess;
            //    user = await DoLogin(userService, user, username, password);
            //    if (user != null)
            //    {
            //        loader.IsVisible = false;
            //        loader.IsRunning = false;
            //        intro.IsEnabled = true;
            //        Application.Current.MainPage = new RootPage(user);
            //    }
            //    else
            //    {
            //        loader.IsVisible = false;
            //        loader.IsRunning = false;
            //        intro.IsEnabled = true;
            //        await DisplayAlert("Login Expired", "Your session has expired. Please login again.", "OK");
            //    }
            //}
            var cacheDir = FileSystem.CacheDirectory;
        }

        private static async System.Threading.Tasks.Task<User> DoLogin(UserService userService, User user, string username, string password)
        {
            if (username != null && username.Length > 0 && username != "" && password != null && password.Length > 0 && password != "")
            {
                user = await userService.GetUser(username, (string)Application.Current.Properties["curUserpass"]);
            }
            else
            {
                return null;
            }

            return user;
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            Models.User user;
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            if (username != null && username.Length > 0 && username != "" && password != null && password.Length > 0 && password != "")
            {
                loader.IsVisible = true;
                loader.IsRunning = true;
                intro.IsEnabled = false;
                var current = Connectivity.NetworkAccess;
                user = await userService.GetUser(username, password);
                if (user != null)
                {
                    Application.Current.Properties["curUsername"] = username;
                    Application.Current.Properties["curUserpass"] = password;
                    loader.IsVisible = false;
                    loader.IsRunning = false;
                    intro.IsEnabled = true;
                    Application.Current.MainPage = new RootPage(user);
                }
                else if (user == null && current != NetworkAccess.Internet)
                {
                    loader.IsVisible = false;
                    loader.IsRunning = false;
                    intro.IsEnabled = true;
                    await DisplayAlert("Connection Error", "It seems you aren't connected to the Internet", "OK");
                }
                else
                {
                    loader.IsVisible = false;
                    loader.IsRunning = false;
                    intro.IsEnabled = true;
                    await DisplayAlert("Login Error", "Your details were incorrect. Try again", "OK");
                }
            }
            else
            {
                await DisplayAlert("Attention", "Please in your login details", "OK");
            }
        }

        private async void GotoSignup(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new SignupPage());
        }

        private async void KeepLogin(object sender, EventArgs e)
        {
            keepLogin = (bool) Application.Current.Properties["keepLogin"];
            keepLoginImage.Source = keepLogin ? "dont_keep_login.png" : (ImageSource)"keep_login.png";
            await App.SaveProperty("keepLogin", !keepLogin);

        }
    }
}