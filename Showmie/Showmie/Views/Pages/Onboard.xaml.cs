using Android.App;
using Showmie.Views;
using System;
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
            boardsCarousel.PositionChanged += BoardsCarousel_PositionChanged;
        }

        private void BoardsCarousel_PositionChanged(object sender, int newPostion)
        {
            boardsCarousel.TabIndex = newPostion;
        }

        public Onboard(bool isFirstLoad, int boardPosition) : this(isFirstLoad)
        {
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

        private async void NextBoard_Clicked(object sender, EventArgs e)
        {
            if (boardsCarousel.TabIndex < onboardsVM.NoOfBoards() - 1)
            {
                boardsCarousel.ScrollTo(boardsCarousel.TabIndex + 1);
            }
            else if (boardsCarousel.TabIndex == onboardsVM.NoOfBoards() - 1)
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
            boardsCarousel.TabIndex = BoardPosition;
            base.OnAppearing();
        }

        private void BoardsCarousel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == TabIndexProperty.PropertyName)
            {
                SourceImage = boardsCarousel.TabIndex;
                OnboardPositionChanged(boardsCarousel.TabIndex);
            }
        }
    }
}