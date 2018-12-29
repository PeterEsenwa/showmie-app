using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = Showmie.Models.MenuItem;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        private Models.User CurrentUser { get; set; }

        private List<Page> Pages = new List<Page>();
        private Page CurrentDetail;

        public RootPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new HomePage());

            MasterPage.MenuItemsListView.SelectedItem = RootPageMaster.MenuItems[0][0];
            foreach (Models.MenuItemGroup menuItemGroup in RootPageMaster.MenuItems)
            {
                foreach (MenuItem menuItem in menuItemGroup)
                {
                    var page = (Page)Activator.CreateInstance(menuItem.TargetType);
                    page.Title = menuItem.Title;
                    Pages.Add(page);
                }
            }
            IsPresentedChanged += HandlePresentationChange;
        }

        public RootPage(Models.User User)
        {
            InitializeComponent();
            CurrentUser = User;
            Detail = new NavigationPage(new HomePage());

            MasterPage.MenuItemsListView.SelectedItem = RootPageMaster.MenuItems[0][0];
            foreach (Models.MenuItemGroup menuItemGroup in RootPageMaster.MenuItems)
            {
                foreach (MenuItem menuItem in menuItemGroup)
                {
                    var page = (Page)Activator.CreateInstance(menuItem.TargetType);
                    page.Title = menuItem.Title;
                    Pages.Add(page);
                }
            }
            IsPresentedChanged += HandlePresentationChange;
        }

        private void HandlePresentationChange(object sender, EventArgs e)
        {
            if (IsPresented == false)
            {
                Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(300);
                    Detail = CurrentDetail;
                });
            }
        }

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            if (CurrentUser == null)
            {
                await DisplayAlert("Sorry", "You need to Login again.", "OK");
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                try
                {
                    if (!MasterPage.Equals(null))
                    {
                        MasterPage.Hello.Text = "Hi " + CurrentUser.Username;

                        CurrentUser.IntFollowers = CurrentUser.Followers.Trim().Split(',').Length;
                        MasterPage.Followers.Text = CurrentUser.IntFollowers.ToString();
                        //MasterPage.userImage.Source = CurrentUser.ProfilePicture;
                        if (CurrentUser.ProfilePicture != null && CurrentUser.ProfilePicture.Trim() != "")
                        {
                            Uri profilePic = new Uri(CurrentUser.ProfilePicture);
                            MasterPage.userImage.Source = new UriImageSource
                            {
                                Uri = profilePic,
                                CachingEnabled = true,
                                CacheValidity = new TimeSpan(5, 0, 0, 0)
                            };
                        }
                        if (CurrentUser.ProfileCover != null && CurrentUser.ProfileCover.Trim() != "")
                        {
                            MasterPage.CoverImage.Source = new UriImageSource
                            {
                                Uri = new Uri(CurrentUser.ProfileCover),
                                CachingEnabled = true,
                                CacheValidity = new TimeSpan(5, 0, 0, 0)
                            };
                        }

                        MasterPage.userImage.Aspect = Aspect.AspectFill;
                        MasterPage.MenuItemsListView.ItemSelected += ListView_ItemSelected;

                        //MasterPage.ListView.SelectedItem = new MenuItem() { Title = "Home" };
                    }
                }
                catch (Exception ex)
                {

                }

            }
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
            NavigationPage navigationPage;

            foreach (Page createdPage in Pages)
            {
                if (createdPage.Title == item.Title)
                {
                    var page = createdPage;
                    navigationPage = new NavigationPage(page)
                    {
                        BarBackgroundColor = Color.Red,
                        Icon = "nav_menu_button.png"
                    };
                    CurrentDetail = navigationPage;
                    IsPresented = false;
                    break;
                }
            }



            //if (item.TargetType == typeof(ExplorePage))
            //{
            //    //int barHeight =  200 / 14 * (int)Device.GetNamedSize(NamedSize.Large, typeof(Label));
            //    //navigationPage.On<Xamarin.Forms.PlatformConfiguration.Android>().SetBarHeight(barHeight);
            //    //navigationPage.BarBackgroundColor = Color.Red;
            //}

            //MasterPage.MenuItemsListView.SelectedItem = null;
        }

    }
}