using Showmie.Models;
using Showmie.Views.CustomViews;
using SlideOverKit;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExplorePage : TabbedPage
    {
        public ExplorePage()
        {
            InitializeComponent();
            BindingContext = this;
            //DependencyService.Get<IAndroidMethods>().ShowBar();
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetBarSelectedItemColor(this, Color.White);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSmoothScrollEnabled(this, true);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);
            //Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetOffscreenPageLimit(this, 4);

        }

        public SlideMenuView SlideMenu { get; set; }
        public Action ShowMenuAction { get; set; }
        public Action HideMenuAction { get; set; }

        private void Filter_Clicked(object sender, EventArgs e)
        {
            if (((ToolbarItem)sender).Icon.File == "filter_icon.png")
            {
                ((ToolbarItem)sender).Icon = "filter_toggled_icon.png";
                ExploreTab currentPage = (ExploreTab)CurrentPage;
                CoordinatorPage currentCoordinator = (CoordinatorPage)currentPage.Content;
                currentCoordinator.ShowFiltersAction();
            }
            else
            {
                ((ToolbarItem)sender).Icon = "filter_icon.png";
            }
        }
    }
}