using System;
using Xamarin.Forms;

namespace Showmie.Models
{
    public class FeaturedItem
    {
        public Image PostImage { get; set; }
        public string Title { get; set; }
        public string Contributor { get; set; }

        public FeaturedItem()
        {

        }

        public FeaturedItem(Image postImage, string title, string contributor)
        {
            if (postImage.Equals(null) || postImage == null)
            {
                PostImage = new Image() { Source = "" };
            }
            else
            {
                PostImage = postImage;
            }
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Contributor = contributor ?? throw new ArgumentNullException(nameof(contributor));
        }

        public FeaturedItem(string postImageSrc, string title, string contributor)
        {
            if (postImageSrc.Equals(null) || postImageSrc == null || postImageSrc == "")
            {
                PostImage = new Image() { Source = "" };
            }
            else
            {
                PostImage = new Image() { Source = postImageSrc };
            }
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Contributor = contributor ?? throw new ArgumentNullException(nameof(contributor));
        }
    }
}
