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
            UserService userService = new UserService();
            User user = new User();
            //Todo : Move auto login logic to App.xaml.cs
            if (Application.Current.Properties.ContainsKey("firstLoad") && !(bool)Application.Current.Properties["firstLoad"])
            {
                if (Application.Current.Properties.ContainsKey("curUsername") && Application.Current.Properties.ContainsKey("curUserpass"))
                {
                    user = await new UserService().UserLogin((string)Application.Current.Properties["curUsername"], (string)Application.Current.Properties["curUserpass"]);
                    if (user != null)
                    {
                        Application.Current.MainPage = new RootPage(user);
                    }
                }
            }
            base.OnAppearing();
            var cacheDir = FileSystem.CacheDirectory;
        }

        private static async System.Threading.Tasks.Task<User> DoLogin(UserService userService, User user, string username, string password)
        {
            if (username != null && username.Length > 0 && username != "" && password != null && password.Length > 0 && password != "")
            {
                user = await userService.UserLogin(username, (string)Application.Current.Properties["curUserpass"]);
            }
            else
            {
                return null;
            }

            return user;
        }

        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            string username = usernameInput.Text;
            string password = passwordInput.Text;

            if (username != null && username.Length > 0 && username != "" && password != null && password.Length > 0 && password != "")
            {
                loader.IsVisible = true;
                loader.IsRunning = true;
                mainGrid.IsEnabled = false;
                NetworkAccess current = Connectivity.NetworkAccess;
                UserService userService = new UserService();
                User user = await userService.UserLogin(username, password);
                loader.IsVisible = false;
                loader.IsRunning = false;
                mainGrid.IsEnabled = true;
                if (user != null)
                {
                    Application.Current.Properties["curUsername"] = username;
                    Application.Current.Properties["curUserpass"] = password;
                    Application.Current.MainPage = new RootPage(user);
                }
                else if (user == null && current != NetworkAccess.Internet)
                {
                    await DisplayAlert("Connection Error", "It seems you aren't connected to the Internet", "OK");
                }
                else
                {
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
            bool keepLoginExist = Application.Current.Properties.TryGetValue("keepLogin", out object tempVal);
            if (keepLoginExist)
            {
                keepLogin = (bool)tempVal;
                keepLoginImage.Source = keepLogin ? "dont_keep_login.png" : (ImageSource)"keep_login.png";
                await App.SaveProperty("keepLogin", !keepLogin); 
            }
            else
            {
                await App.SaveProperty("keepLogin", true);
                keepLoginImage.Source = keepLogin ? "dont_keep_login.png" : (ImageSource)"keep_login.png";
            }
        }
    }
}