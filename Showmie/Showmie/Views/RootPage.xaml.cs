using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuItem = Showmie.Models.MenuItem;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Showmie.Models;

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

            NavigationPage navigationPage = new NavigationPage(page);
            //navigationPage.
            Detail = navigationPage;
            IsPresented = false;

            MasterPage.MenuItemsListView.SelectedItem = null;
        }
    }
}