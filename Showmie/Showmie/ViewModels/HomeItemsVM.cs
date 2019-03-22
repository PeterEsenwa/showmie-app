using Showmie.Models;
using System.Collections.ObjectModel;

namespace Showmie.ViewModels
{
    public class HomeItemsVm
    {
        public ObservableCollection<FeaturedItem> ItemsList { get; set; } = new ObservableCollection<FeaturedItem>();

        public ObservableCollection<FeaturedItem> GetItems()
        {
            var item1 = new FeaturedItem("black_essence.png", "BLACK ESSENCE", "petrilevi");
            var item2 = new FeaturedItem("womens_day.png", "WOMEN'S DAY", "petrilevi");
            var item3 = new FeaturedItem("womens_day.png", "WOMEN'S DAY", "petrilevi");
            var item4 = new FeaturedItem("black_essence.png", "BLACK ESSENCE", "petrilevi");
            //FeaturedItem item3 = new FeaturedItem("light_africa.png", "WHITE AFRICANA", "mr nobody");
            
            ItemsList.Add(item1);
            ItemsList.Add(item2);
            ItemsList.Add(item3);
            ItemsList.Add(item4);
            return ItemsList;
        }

        //public int NoOfBoards()
        //{
        //    return BoardsList.Count;
        //}
    }
}
