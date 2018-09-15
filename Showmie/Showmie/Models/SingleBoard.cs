using System;

namespace Showmie
{
    public class SingleBoard
    {
        public string BodyText { get; set; }
        public string HeadingText { get; set; }
        public string DescImageURL { get; set; }

        public SingleBoard( string descImageURL, string headingText, string bodyText )
        {
            DescImageURL = descImageURL ?? throw new ArgumentNullException(nameof(descImageURL));
            HeadingText = headingText ?? throw new ArgumentNullException(nameof(headingText));
            BodyText = bodyText ?? throw new ArgumentNullException(nameof(bodyText));
        }
    }
}
