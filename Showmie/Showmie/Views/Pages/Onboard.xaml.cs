using Android.App;
using Android.Views;
using Showmie.Views;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Onboard : OrientationContentPage, INotifyPropertyChanged
    {
        public int BoardPosition { get; set; }
        public Onboard(bool isFirstLoad)
        {
            InitializeComponent();
            firstPageLoad = isFirstLoad;
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
            DependencyService.Get<IAndroidMethods>().HideBar();
        }

        public Onboard(bool isFirstLoad, int boardPosition)
        {
            InitializeComponent();
            firstPageLoad = isFirstLoad;
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
            BoardPosition = boardPosition;
        }

        public Onboard(bool isFirstLoad, Activity creatorActivity) : this(isFirstLoad)
        {
            this.creatorActivity = creatorActivity;
        }

        private OnboardsVM onboardsVM = new OnboardsVM();
        public List<SingleBoard> BoardsSource { get; set; }
        private int _sourceImage;
        private Activity creatorActivity;

        public int SourceImage { get { return _sourceImage; } set { _sourceImage = value; OnPropertyChanged(); } }

        private async void NextBoard_Clicked(object sender, System.EventArgs e)
        {
            if (boardsCarousel.Position < onboardsVM.NoOfBoards() - 1)
            {
                boardsCarousel.Position++;
            }
            else if (boardsCarousel.Position == onboardsVM.NoOfBoards() - 1)
            {
                await App.SaveProperty("firstLoad", true);
                await App.SaveProperty("keepLogin", false);
                SetMainPage(new NavigationPage(new SignupPage()));
            }
        }

        private async void SkipOnboarding_Clicked(object sender, System.EventArgs e)
        {
            await App.SaveProperty("firstLoad", true);
            await App.SaveProperty("keepLogin", false);
            SetMainPage(new NavigationPage(new SignupPage()));
        }

        protected override void OnAppearing()
        {
            boardsCarousel.Position = BoardPosition;
            base.OnAppearing();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        private void BoardsCarousel_PositionSelected(object sender, SelectedPositionChangedEventArgs e)
        {
            OnboardPositionChanged(boardsCarousel.Position);
        }
    }
}