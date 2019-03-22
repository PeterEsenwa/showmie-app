using Showmie.Models;
using Showmie.Views.Pages;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = Showmie.Models.MenuItem;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageMaster : ContentPage
    {
        public ListView ItemsListView { get; set; }
        public ObservableCollection<MenuItemGroup> MenuItems { get; set; }
        public RootPageMaster()
        {
            InitializeComponent();
            BindingContext = this;
            ItemsListView = MenuItemsListView;
            MenuItems = new ObservableCollection<MenuItemGroup>();
            var mainGroup = new MenuItemGroup
            {
                new MenuItem { Id = 0, Title = "Home", IconSrc = "home_icon.png", Type = MenuItem.ItemType.Normal, TargetType = typeof(HomePage)},
                new MenuItem { Id = 1, Title = "Explore" , IconSrc = "explore_icon.png", Type = MenuItem.ItemType.Normal, TargetType = typeof(ExplorePage)},
                new MenuItem { Id = 2, Title = "Notifications" , IconSrc = "bell_icon.png", Type = MenuItem.ItemType.Normal, TargetType = typeof(NotificationsPage)},
                new MenuItem { Id = 3, Title = "My Showroom" , IconSrc = "showroom_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 4, Title = "Subscriptions" , IconSrc = "subscriptions_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 5, Title = "Challenges" , IconSrc = "trophy_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 6, Title = "Settings" , IconSrc = "cog_icon.png", Type = MenuItem.ItemType.Normal},
            };
            var othersGroup = new MenuItemGroup
            {
                new MenuItem { Id = 0, Title = "Help & Feedback", IconSrc = "", Type = MenuItem.ItemType.Other},
                new MenuItem { Id = 1, Title = "About SHOWMiE" , IconSrc = "", Type  = MenuItem.ItemType.Other}
            };

            MenuItems.Add(mainGroup);
            MenuItems.Add(othersGroup);
            MenuItemsListView.ItemsSource = MenuItems;
            MenuItemsListView.SelectedItem = MenuItems[0][0];
            
        }

    }
    public class ItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalTemplate { get; set; }

        public DataTemplate OtherTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((MenuItem)item).Type == MenuItem.ItemType.Normal ? NormalTemplate : OtherTemplate;
        }
    }
}