using Showmie.Models;
using SlideOverKit;
using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Showmie.Models.FilterItem.ExploreTitles;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExplorePage : TabbedPage
    {
        private static ObservableCollection<FilterItem> FilterItems;

        public ExplorePage()
        {
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetBarSelectedItemColor(this, Color.White);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSmoothScrollEnabled(this, true);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetOffscreenPageLimit(this, 4);

            FilterItems = new ObservableCollection<FilterItem>() {
                new FilterItem(false, Accessories),
                new FilterItem(false, Model),
                new FilterItem(false, MakeUp),
                new FilterItem(false, HairStyles),
                new FilterItem(false, Jewelry),
                new FilterItem(false, Photography),
                new FilterItem(false, OutfitDesigns),
                new FilterItem(false, FashionBlogs)
            };

            Children.Add(new ExploreTab(FilterItems) { Title = "Male" });
            Children.Add(new ExploreTab(FilterItems) { Title = "Female" });
            Children.Add(new ExploreTab(FilterItems) { Title = "Children" });

            InitializeComponent();
        }

        public SlideMenuView SlideMenu { get; set; }
        public Action ShowMenuAction { get; set; }
        public Action HideMenuAction { get; set; }

        private void Filter_Clicked(object sender, EventArgs e)
        {
            if (((ToolbarItem)sender).Icon.File == "filter_icon.png")
            {
                ((ToolbarItem)sender).Icon = "filter_toggled_icon.png";
            }
            else
            {
                ((ToolbarItem)sender).Icon = "filter_icon.png";
            }
        }
    }
}