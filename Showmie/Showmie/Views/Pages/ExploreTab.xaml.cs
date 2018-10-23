using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Showmie.Models;
using System.Collections.ObjectModel;
using Showmie.Views.CustomViews;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreTab : ContentPage
    {
        public static ObservableCollection<FilterItem> FilterItems { get; set; }
        public ExploreTab()
        {
            InitializeComponent();
        }
        public ExploreTab(ObservableCollection<FilterItem> filterItems)
        {
            InitializeComponent();
            FilterItems = filterItems;
            Content = new CoordinatorPage(FilterItems);
        }

    }
}