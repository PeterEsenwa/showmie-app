using Showmie.Models;
using Showmie.Views;
using Showmie.Views.Pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Showmie
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            SizeChanged += SignupPage_SizeChanged;
            //usernameInput.Keyboard = Keyboard.Create(KeyboardFlags.None);
            emailInput.Keyboard = Keyboard.Email;
            MessagingCenter.Subscribe<CustomEntry>(this, "unfocus", (sender) => {
                if (sender is CustomEntry && sender.TabIndex + 1 <= fieldsHolder.Children.Count)
                {
                    int currentIndex = fieldsHolder.Children.IndexOf(sender) + 1;
                    Entry nextEntry = (Entry)fieldsHolder.Children[currentIndex];
                    nextEntry.Focus();
                }
            });
        }

        private void SignupPage_SizeChanged(object sender, EventArgs e)
        {

            if (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Portrait && DeviceDisplay.MainDisplayInfo.Density > 1.5 && Device.RuntimePlatform == Device.Android)
            {
                socialSignup.IsVisible = true;
                MessagingCenter.Send(this, "showingSocialOptions");
            }
            else
            {
                mainGrid.Children.Remove(socialSignup);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ((SwitchButton)sender)?.ToggleSwitch();
        }

        private async void GotoLoginAsync(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new LoginPage());
        }



        private async void HandleSignup(object sender, EventArgs e)
        {
            string password = passwordInput.Text;
            string confirmPassword = confirmInput.Text;
            string username = usernameInput.Text;
            string email = emailInput.Text;

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Incomplete details", "Please complete all details to proceed", "OK");
            }
            else
            {
                if (password.Equals(confirmPassword))
                {
                    User newUser = new User(username, email, password, 0, (int)accountType?.GetAccountType());
                    ContinueSignup page = new ContinueSignup(newUser);
                    await Navigation.PushModalAsync(page);
                }
                else
                {
                    await DisplayAlert("Password Error", "Your passwords don't match.", "OK");
                }
            }

        }
    }
}
