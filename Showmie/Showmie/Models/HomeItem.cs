using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Showmie.Models
{
    public class HomeItem : ObservableCollection<FeaturedItem>
    {
        //public ObservableCollection<FeaturedItem> Items { get; set; } = new ObservableCollection<FeaturedItem>();
        public ItemType Type { get; set; }
        public string Title { get; set; }
        public string Contributor { get; set; }
        public List<FeaturedItem> ItemsList { get; set; } = new List<FeaturedItem>();

        public HomeItem()
        {
            if (Count == 0)
            {
                Type = ItemType.Unknown;
            }
            else if (Count == 1)
            {
                Type = ItemType.Singular;
            }
            else if (Count > 1)
            {
                Type = ItemType.Multiple;
            }
        }

        public HomeItem(FeaturedItem SingleItem)
        {
            ItemsList.Add(SingleItem);
            Type = ItemType.Singular;
        }

        public HomeItem(List<FeaturedItem> Items)
        {
            Items.ForEach(new Action<FeaturedItem>(AddItem));
            
            Type = ItemType.Multiple;
        }

        private void AddItem(FeaturedItem obj)
        {
            ItemsList.Add(obj);
        }

        public HomeItem(ItemType Type)
        {
            this.Type = Type;
        }

        public enum ItemType
        {
            Singular = 0,
            Multiple = 1,
            Unknown = -1
        }
    }
}
