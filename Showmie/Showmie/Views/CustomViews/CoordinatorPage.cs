using Showmie.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    public class CoordinatorPage : Grid
    {

        public static ObservableCollection<FilterItem> FilterItems { get; set; }

        public CoordinatorPage(ObservableCollection<FilterItem>  filterItems)
        {
            FilterItems = filterItems;
        }
    }
}
