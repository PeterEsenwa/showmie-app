using Showmie.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showmie.Models
{
    public class MenuItem
    {
        public MenuItem()
        {
            TargetType = typeof(RootPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string IconSrc { get; set; }
        public Type TargetType { get; set; }
        public ItemType Type { get; set; }

        public enum ItemType
        {
            Normal = 0,
            Other = 1,
            Unknown = -1
        }
    }

    public class MenuItemGroup : ObservableCollection<MenuItem>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Subtitle { get; set; }
        //private MenuItemGroup(string title, string shortName)
        //{
        //    Title = title;
        //    ShortName = shortName;
        //}
    }

}