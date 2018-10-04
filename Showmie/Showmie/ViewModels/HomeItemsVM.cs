using Showmie.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Showmie.ViewModels
{
    internal class HomeItemsVM
    {
        public ObservableCollection<HomeItem> ItemsList { get; set; } = new ObservableCollection<HomeItem>();

        public ObservableCollection<HomeItem> GetItems()
        {
            FeaturedItem mainFeaturedItem = new FeaturedItem("black_essence", "BLACK ESSENCE", "petrilevi");
            List<FeaturedItem> otherFeaturedItems = new List<FeaturedItem>()
            {
                new FeaturedItem("boy_called_cloak", "CLOAK IN RED", "petrilevi"),
                new FeaturedItem("light_africa", "BLACK WHITE", "petrilevi")
            };

            HomeItem mainItem = new HomeItem(SingleItem: mainFeaturedItem);
            HomeItem otherItems = new HomeItem(Items: otherFeaturedItems);

            mainItem.Title = "BLACK ESSENCE";
            mainItem.Contributor = "petrilevi";
            otherItems.Title = "";
            otherItems.Contributor = "petrilevi";

            ItemsList.Add(mainItem);
            ItemsList.Add(otherItems);
            return ItemsList;
        }

        //public int NoOfBoards()
        //{
        //    return BoardsList.Count;
        //}
    }
}
