using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Models
{
    public class FilterItem
    {
        public bool IsChecked { get; set; }
        public string Title { get; set; }
        public Color CheckedBackgroundColor {
            get; set; 
        }
        public Color UnCheckedBackgroundColor {
            get; set; 
        }

        public struct ExploreTitles
        {
            public const string Accessories = "Accessories";
            public const string Model = "Model";
            public const string MakeUp = "Make Up";
            public const string HairStyles = "Hair Styles";
            public const string Jewelry = "Jewelry";
            public const string Photography = "Photography";
            public const string OutfitDesigns = "Outfit Designs";
            public const string FashionBlogs = "Fashion Blogs";
        }
        public FilterItem(bool isChecked, string title, Color checkedBackgroundColor, Color unCheckedBackgroundColor)
        {
            IsChecked = isChecked;
            Title = title ?? throw new ArgumentNullException(nameof(title));
            CheckedBackgroundColor = checkedBackgroundColor;
            UnCheckedBackgroundColor = unCheckedBackgroundColor;
        }
    }
}
