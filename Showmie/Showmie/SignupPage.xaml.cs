using Showmie.Views;
using System;
using Xamarin.Forms;

namespace Showmie
{
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }
        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ((SwitchButton) sender)?.ToggleSwitch();
        }

        private async void GotoLoginAsync(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
            await Navigation.PushAsync(new LoginPage());
        }

        private void HandleSignup(object sender, EventArgs e)
        {
            //DependencyService.Get<IAndroidMethods>().SetActionBarIcon();
            //Application.Current.MainPage = new RootPage();
        }
    }
}
