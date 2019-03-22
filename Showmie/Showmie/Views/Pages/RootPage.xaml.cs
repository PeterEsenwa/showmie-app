using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = Showmie.Models.MenuItem;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage
    {
        private List<Page> Pages { get; } = new List<Page>();

        public RootPage()
        {
            InitializeComponent();
            foreach (Models.MenuItemGroup menuItemGroup in MasterPage.MenuItems)
            {
                foreach (MenuItem menuItem in menuItemGroup)
                {
                    var page = (Page)Activator.CreateInstance(menuItem.TargetType);
                    page.Title = menuItem.Title;
                    Pages.Add(page);
                }
            }
            MasterPage.ItemsListView.ItemSelected += ListView_ItemSelected;
            var navigationPage = new NavigationPage(Pages[0])
            {
                //BarBackgroundColor = Color.Red,
                Icon = "nav_menu_button.png"
            };
            Detail = navigationPage;
        }

        public RootPage(Models.User user)
        {
            InitializeComponent();
            App.CurrentUser = user ?? throw new ArgumentNullException(nameof(user));

            MasterPage.ItemsListView.ItemSelected += ListView_ItemSelected;
            foreach (Models.MenuItemGroup menuItemGroup in MasterPage.MenuItems)
            {
                foreach (MenuItem menuItem in menuItemGroup)
                {
                    var page = (Page)Activator.CreateInstance(menuItem.TargetType);
                    page.Title = menuItem.Title;
                    Pages.Add(page);
                }
            }
            var navigationPage = new NavigationPage(Pages[0])
            {
                //BarBackgroundColor = Color.Red,
                Icon = "nav_menu_button.png"
            };
            Detail = navigationPage;
        }
  
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /**
             * Do null checks on the sender and the SelectedItem
             */
            if (!(e.SelectedItem is MenuItem menuItem)) return;
            if (sender == null) return;
            foreach (Page createdPage in Pages)
            {
                if (createdPage.Title != menuItem.Title) continue;

                Page page = createdPage;
                var navigationPage = new NavigationPage(page)
                {
                    //BarBackgroundColor = Color.Red,
                    Icon = "nav_menu_button.png"
                };
                Detail = navigationPage;
                IsPresented = false;
                break;
            }
        }

    }
}