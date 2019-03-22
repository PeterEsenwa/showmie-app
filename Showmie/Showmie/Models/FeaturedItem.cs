using System;
using Xamarin.Forms;

namespace Showmie.Models
{
    public class FeaturedItem
    {
        public string PostImage { get; set; }
        public string Title { get; set; }
        public string Contributor { get; set; }

        public FeaturedItem()
        {

        }

        public FeaturedItem(string postImage, string title, string contributor)
        {
            PostImage = postImage ?? throw new ArgumentNullException(nameof(postImage));
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Contributor = contributor ?? throw new ArgumentNullException(nameof(contributor));
        }
    }
}
