using Showmie.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Showmie.ViewModels
{
    public class FilterItemsVM
    {
        internal ObservableCollection<FilterItem> ItemsList { get; set; } = new ObservableCollection<FilterItem>();

        public FilterItemsVM(ObservableCollection<FilterItem> itemsList)
        {
            ItemsList = itemsList ?? throw new ArgumentNullException(nameof(itemsList));
        }

        public ObservableCollection<FilterItem> GetItems()
        {
            if (ItemsList != null && ItemsList.Count > 0)
            {
                return ItemsList;
            }
            else
            {
                throw new ArgumentNullException(nameof(ItemsList));
            }
        }
    }
}
