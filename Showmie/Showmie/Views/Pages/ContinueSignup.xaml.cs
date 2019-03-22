using Showmie.Droid;
using Showmie.Models;
using Showmie.Utils;
using Showmie.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContinueSignup : ContentPage
    {
        public ObservableCollection<States> ListOfStates { get; set; }
        public User NewUser { get; }

        public ContinueSignup(User newUser)
        {
            InitializeComponent();
            BindingContext = this;
            DoBEntry.MinimumDate = new DateTime(1919, 1, 1);
            DoBEntry.MaximumDate = new DateTime(2004, 12, 31);
            DoBEntry.Date = DateTime.Today;
            NewUser = newUser ?? throw new ArgumentNullException(nameof(newUser));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListOfStates = await new StatesVM().GetStatesFromJSON();
            StateOfResidence.ItemsSource = ListOfStates;
            MessagingCenter.Send(this, "RequestLocation");
            MessagingCenter.Subscribe<PhoneVerificationDialog>(this, "PhoneAuthenticationDone", (sender) =>
            {
                DoVerification.Text = "verified";
                DoVerification.GestureRecognizers.Clear();
                NewUser.PhoneNoVerification = "Yes";
            });
        }

        private async void ContinueButton_Clicked(object sender, EventArgs e)
        {
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            DateTime DoB = DoBEntry.Date;
            string state = ((States)StateOfResidence.SelectedItem).Name;
            //TODO: Add phone number verification step
            string phone = phoneNumberEntry.Text;
            bool isMale = MaleSwitch.IsChecked;
            bool isFemale = FemaleSwitch.IsChecked;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || DoB == null || string.IsNullOrWhiteSpace(state) || string.IsNullOrWhiteSpace(phone))
            {
                await DisplayAlert("Incomplete details", "Please complete all details to proceed", "OK");
            }
            else if (!isMale && !isFemale)
            {
                await DisplayAlert("Incomplete details", "Please select your gender", "OK");
            }
            else
            {
                NewUser.Country = "Nigeria";
                NewUser.FirstName = firstName;
                NewUser.LastName = lastName;
                NewUser.DateOfBirth = DoB;
                NewUser.PhoneNo = phone;
                NewUser.Gender = isMale ? "Male" : "Female";
                NewUser.State = state;
                UserService userService = new UserService();

                User returnedUser = await UserService.DoSignup(userService, NewUser);
                if (returnedUser == null)
                {
                    await DisplayAlert("An Error occurred", "Please check your signup details", "OK");
                }
                else
                {
                    Application.Current.MainPage = new RootPage(returnedUser);
                }
            }
        }
        /// <summary>
        /// OnClick event handler for verify button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerifyPhoneNumber(object sender, EventArgs e)
        {
            if (phoneNumberEntry.Text != null && phoneNumberEntry.Text.Trim() != "")
            {
                DependencyService.Get<IFirebaseAuthFunctions>().AuthenticatePhone(phoneNumberEntry.Text);
            }
        }
    }
}