using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = Showmie.Models.MenuItem;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            if (!MasterPage.Equals(null))
            {
                MasterPage.MenuItemsListView.ItemSelected += ListView_ItemSelected;
                //MasterPage.ListView.SelectedItem = new MenuItem() { Title = "Home" };
            }
        }

        protected override void OnAppearing()
        {
            MasterPage.MenuItemsListView.SelectedItem = RootPageMaster.MenuItems[0][0];
            base.OnAppearing();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (sender.Equals(null) || e.SelectedItem == null)
            {
                return;
            }
            if (!(e.SelectedItem is MenuItem item))
            {
                return;
            }

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            NavigationPage navigationPage = new NavigationPage(page)
            {
                BarBackgroundColor = Color.Red,
                Icon = "nav_menu_button.png"
            };

            if (item.TargetType == typeof(ExplorePage))
            {
                //int barHeight =  200 / 14 * (int)Device.GetNamedSize(NamedSize.Large, typeof(Label));
                //navigationPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetBarHeight(barHeight);
                //navigationPage.BarBackgroundColor = Color.Red;
            }
            Detail = navigationPage;
            IsPresented = false;

            MasterPage.MenuItemsListView.SelectedItem = null;
        }
    }
}