using Showmie.Models;
using Showmie.ViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
            HomeItemsSource = HomeItemsVm.GetItems();
            BindingContext = this;
            Title = "Home";
        }

        protected override async void OnAppearing()
        {
            featuredListView.SetBinding(ItemsView.ItemsSourceProperty, "HomeItemsSource");
            await App.SaveProperty("firstLoad", false);
            base.OnAppearing();
        }

        public HomeItemsVm HomeItemsVm { get; } = new HomeItemsVm();
        public ObservableCollection<FeaturedItem> HomeItemsSource { get; set; }
    }
}