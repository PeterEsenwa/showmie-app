using Showmie.Views;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Onboard: OrientationContentPage, INotifyPropertyChanged
    {
        public Onboard(bool isFirstLoad)
        {
            InitializeComponent();
            firstPageLoad = isFirstLoad;
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
        }
        public Onboard(bool isFirstLoad, int boardPosition)
        {
            InitializeComponent();
            firstPageLoad = isFirstLoad;
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
            boardsCarousel.Position = boardPosition;
        }
        
        OnboardsVM onboardsVM = new OnboardsVM();
        public List<SingleBoard> BoardsSource { get; set; }
        private int _sourceImage;
        public int SourceImage { get { return _sourceImage; } set { _sourceImage = value; OnPropertyChanged(); } }

        private void NextBoard_Clicked(object sender, System.EventArgs e)
        {
            if (boardsCarousel.Position < onboardsVM.NoOfBoards() - 1)
            {
                boardsCarousel.Position++;
            }
        }



        private void SkipOnboarding_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new SignupPage();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }



        protected override bool OnBackButtonPressed()
        {
            if (Device.RuntimePlatform == Device.Android)
                DependencyService.Get<IAndroidMethods>().CloseApp();

            return base.OnBackButtonPressed();
        }

        private void BoardsCarousel_PositionSelected(object sender, SelectedPositionChangedEventArgs e)
        {
            OnboardPositionChanged(boardsCarousel.Position);
        }
    }
}