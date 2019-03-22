using Showmie.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardLandscape : OrientationContentPage
    {
        public int BoardPosition { get; set; }
        public OnboardLandscape(bool isFirstLoad)
        {
            InitializeComponent();
            firstPageLoad = isFirstLoad;
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
        }

        public OnboardLandscape(bool isFirstLoad, int boardPosition)
        {
            InitializeComponent();
            firstPageLoad = isFirstLoad;
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
            BoardPosition = boardPosition;
        }
        private OnboardsVM onboardsVM = new OnboardsVM();
        public List<SingleBoard> BoardsSource { get; set; }
        private int _sourceImage;

        public int SourceImage { get { return _sourceImage; } set { _sourceImage = value; OnPropertyChanged(); } }

        private void NextBoard_Clicked(object sender, EventArgs e)
        {
            if (boardsCarousel.TabIndex < onboardsVM.NoOfBoards() - 1)
            {
                boardsCarousel.TabIndex++;
            }
            else if (boardsCarousel.TabIndex == onboardsVM.NoOfBoards() - 1)
            {
                SetMainPage(new NavigationPage(new SignupPage()));
            }
        }

        private void SkipOnboarding_Clicked(object sender, EventArgs e)
        {
            SetMainPage(new NavigationPage(new SignupPage()));
        }

        protected override void OnAppearing()
        {
            boardsCarousel.TabIndex = BoardPosition;
            base.OnAppearing();
        }

        private void BoardsCarousel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == CarouselView.TabIndexProperty.PropertyName)
            {
                OnboardPositionChanged(boardsCarousel.TabIndex);
            }
        }
    }
}