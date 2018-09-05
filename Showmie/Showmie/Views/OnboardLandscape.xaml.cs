using Showmie.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OnboardLandscape : OrientationContentPage
	{
		public OnboardLandscape (bool firstPageLoad)
		{
            OrientationContentPage.firstPageLoad = firstPageLoad;
            InitializeComponent ();
            BoardsSource = onboardsVM.GetBoards();
            SourceImage = 0;
            BindingContext = this;
        }
        OnboardsVM onboardsVM = new OnboardsVM();
        public List<SingleBoard> BoardsSource { get; set; }
        private int _sourceImage;
        public int SourceImage { get { return _sourceImage; } set { _sourceImage = value; OnPropertyChanged(); } }

        private void NextBoard_Clicked(object sender, EventArgs e)
        {
            if (boardsCarousel.Position < onboardsVM.NoOfBoards() - 1)
            {
                boardsCarousel.Position++;
            }
        }

        private void SkipOnboarding_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new SignupPage());
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

    }
}