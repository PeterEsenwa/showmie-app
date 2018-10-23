using Showmie.Models;
using Showmie.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            HomeItemsSource = homeItemsVM.GetItems();
            BindingContext = this;
            Title = "Home";
        }

        private HomeItemsVM homeItemsVM = new HomeItemsVM();
        public ObservableCollection<HomeItem> HomeItemsSource { get; set; }
    }

    public class HomeItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SingleTemplate { get; set; }

        public DataTemplate MultipleTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((HomeItem)item).Type == HomeItem.ItemType.Singular ? SingleTemplate : MultipleTemplate;
        }
    }
}