using Showmie.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MenuItem = Showmie.Models.MenuItem;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPageMaster : ContentPage
    {
        public static ObservableCollection<MenuItemGroup> MenuItems { get; set; }
        public RootPageMaster()
        {
            InitializeComponent();
            BindingContext = this;
            MenuItems = new ObservableCollection<MenuItemGroup>();
            var mainGroup = new MenuItemGroup() {
                new MenuItem { Id = 0, Title = "Home", IconSrc = "home_icon.png", Type = MenuItem.ItemType.Normal, TargetType = typeof(HomePage)},
                new MenuItem { Id = 1, Title = "Explore" , IconSrc = "explore_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 2, Title = "Notifications" , IconSrc = "bell_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 3, Title = "My Showroom" , IconSrc = "showroom_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 4, Title = "Subscriptions" , IconSrc = "subsricptions_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 5, Title = "Challenges" , IconSrc = "trophy_icon.png", Type = MenuItem.ItemType.Normal},
                new MenuItem { Id = 6, Title = "Settings" , IconSrc = "cog_icon.png", Type = MenuItem.ItemType.Normal},
            };
            var othersGroup = new MenuItemGroup() {
                new MenuItem { Id = 0, Title = "Help & Feedback", IconSrc = "", Type = MenuItem.ItemType.Other},
                new MenuItem { Id = 1, Title = "About SHOWMiE" , IconSrc = "", Type  = MenuItem.ItemType.Other}
            };

            MenuItems.Add(mainGroup);
            MenuItems.Add(othersGroup);
            //ListView.ItemsSource = MenuItems;
            MenuItemsListView.ItemsSource = MenuItems;
            //MenuItemsListView.SelectionMode = ListViewSelectionMode.None;
        }

        //public static RootPageMasterViewModel BContext { get; set; }

        //public class RootPageMasterViewModel : INotifyPropertyChanged
        //{
        //    public ObservableCollection<MenuItem> MenuItems { get; set; }
        //    public ObservableCollection<MenuItem> OtherItems { get; set; }

        //    public RootPageMasterViewModel()
        //    {
        //        MenuItems = new ObservableCollection<MenuItem>(new[]
        //        {
        //            new MenuItem { Id = 0, Title = "Home", IconSrc = "home_icon.png"},
        //            new MenuItem { Id = 1, Title = "Explore" , IconSrc = "explore_icon.png"},
        //            new MenuItem { Id = 2, Title = "Notifications" , IconSrc = "bell_icon.png"},
        //            new MenuItem { Id = 3, Title = "My Showroom" , IconSrc = "showroom_icon.png"},
        //            new MenuItem { Id = 4, Title = "Subscriptions" , IconSrc = "subsricptions_icon.png"},
        //            new MenuItem { Id = 5, Title = "Challenges" , IconSrc = "trophy_icon.png"},
        //            new MenuItem { Id = 6, Title = "Settings" , IconSrc = "cog_icon.png"},
        //        });
        //        OtherItems = new ObservableCollection<MenuItem>(new[]
        //        {
        //            new MenuItem { Id = 0, Title = "Help & Feedback", IconSrc = ""},
        //            new MenuItem { Id = 1, Title = "About SHOWMiE" , IconSrc = ""}
        //        });
        //    }

        //    #region INotifyPropertyChanged Implementation
        //    public event PropertyChangedEventHandler PropertyChanged;

        //    private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    {
        //        if (PropertyChanged == null)
        //            return;

        //        PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //    #endregion
        //}


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