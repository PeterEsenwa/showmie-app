using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Showmie.Views.CustomViews
{
    internal class ExploreCard : View
    {

    }

    public class ExploreCardHolder : StackLayout
    {
        public Label Label { get; set; } = new Label() { TextColor = Color.White,Text = "Motiv8" };
        public ScrollView ScrollableContainer { get; set; } = new ScrollView();
        public string SortPattern {
            get { return (string)GetValue(SortPatternProperty); }
            set { SetValue(SortPatternProperty, value ?? throw new NullReferenceException("SortPattern value cannot be null or empty string.")); }
        }

        public static BindableProperty SortPatternProperty { get; } = BindableProperty.Create(
            "SortPattern",
            typeof(string),
            typeof(ExploreCardHolder),
            "Most Recent",
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                ExploreCardHolder exploreCardHolder = (bindable as ExploreCardHolder);
                exploreCardHolder.Label.Text = (string)newvalue;

            });

        public ExploreCardHolder() : base()
        {
            BackgroundColor = Color.Gainsboro;
            Orientation = StackOrientation.Vertical;
            ScrollableContainer.Orientation = ScrollOrientation.Horizontal;
            ScrollableContainer.BackgroundColor = Color.White;
            ScrollableContainer.MinimumHeightRequest = 80;
            ScrollableContainer.MinimumWidthRequest = 80;
            Children.Add(Label);
            Children.Add(ScrollableContainer);

        }

    }

}
