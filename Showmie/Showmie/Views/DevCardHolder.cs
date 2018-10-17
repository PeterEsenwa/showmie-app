using Showmie.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Showmie.Views
{
    public class CardHolder : Grid
    {
        private StackLayout TitleAndDesc = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Spacing = -6,
            BackgroundColor = (Color)Application.Current.Resources["TextColorLightGreyTRANS"],
            Margin = new Thickness(16, 8, 16, 0),
        };

        public Image PostImage { get; set; } = new Image()
        {
            BackgroundColor = Color.Coral,
            Source = "boy_called_cloak",
            VerticalOptions = LayoutOptions.Start,
            Aspect= Aspect.AspectFill
        };

        public CardHolder()
        {
            this.SetBinding(ItemsProperty, "ItemsList");

            if (Title != null && Description != null)
            {
                TitleAndDesc.Children.Add(Title);
                TitleAndDesc.Children.Add(Description);
            }
            //PostImage.HorizontalOptions = LayoutOptions.Center;
            //PostImage.VerticalOptions = LayoutOptions.Start;
            PostImage.Margin = 0;
            TitleAndDesc.VerticalOptions = LayoutOptions.Start;
            Children.Add(PostImage, 0, 0);
            Children.Add(TitleAndDesc, 0, 0);
            HeightRequest = -1;
        }

        private static BindableProperty ItemsProperty { get; } = BindableProperty.Create(
          "Items",
          typeof(List<FeaturedItem>),
          typeof(CardHolder),
          new List<FeaturedItem>(2),
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              OnItemsChanged(bindable, newvalue);
              ((CardHolder)bindable).HeightRequest = ((List<FeaturedItem>)newvalue)[0].PostImage.Height;
              
          });

        private static void OnItemsChanged(BindableObject bindable, object newvalue)
        {
            if (newvalue is List<FeaturedItem>)
            {
                Image postImage = ((List<FeaturedItem>)newvalue)[0].PostImage;
                ((CardHolder)bindable).PostImage.Source = postImage.Source;
            }
        }

        public List<FeaturedItem> Items {
            get {
                return (List<FeaturedItem>)GetValue(ItemsProperty);
            }

            set {
                SetValue(ItemsProperty, value);
                OnPropertyChanged("Items");
            }
        }

        #region Title Property implemention
        public Label Title {
            get { return (Label)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        private static BindableProperty TitleProperty { get; } = BindableProperty.Create(
          "Title",
          typeof(Label),
          typeof(CardHolder),
          new Label() { Text = "Title goes here" },
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              ((CardHolder)bindable).TitleAndDesc.Children.RemoveAt(0);
              ((CardHolder)bindable).TitleAndDesc.Children.Insert(0, (View)newvalue);
          });
        #endregion

        #region Description Property implemention
        public Label Description {
            get { return (Label)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        private static BindableProperty DescriptionProperty { get; } = BindableProperty.Create(
          "Description",
          typeof(Label),
          typeof(CardHolder),
          new Label() { Text = "Description goes here" },
          propertyChanged: (bindable, oldvalue, newvalue) =>
          {
              ((CardHolder)bindable).TitleAndDesc.Children.RemoveAt(1);
              ((CardHolder)bindable).TitleAndDesc.Children.Insert(1, (View)newvalue);
          });
        #endregion  

    }

    public class MultiCardHolder : Grid
    {
        public ShadowedImage LeftPostImage { get; set; } = new ShadowedImage();
        public ShadowedImage RightPostImage { get; set; } = new ShadowedImage();

        public MultiCardHolder()
        {
            this.SetBinding(ItemsProperty, "ItemsList");

            LeftPostImage.HorizontalOptions = LayoutOptions.Center;
            RightPostImage.HorizontalOptions = LayoutOptions.Center;
            Children.Add(LeftPostImage, 0, 0);
            Children.Add(RightPostImage, 1, 0);
        }

        private static BindableProperty ItemsProperty { get; } = BindableProperty.Create(
        "Items",
        typeof(List<FeaturedItem>),
        typeof(MultiCardHolder),
        new List<FeaturedItem>(2),
        propertyChanged: (bindable, oldvalue, newvalue) =>
        {
            OnItemsChanged(bindable, newvalue);
        });

        private static void OnItemsChanged(BindableObject bindable, object newvalue)
        {
            Image leftPostImage = ((List<FeaturedItem>)newvalue)[0].PostImage;
            Image rightPostImage = ((List<FeaturedItem>)newvalue)[1].PostImage;
            ((MultiCardHolder)bindable).LeftPostImage.Source = leftPostImage.Source;
            ((MultiCardHolder)bindable).RightPostImage.Source = rightPostImage.Source;
            ((MultiCardHolder)bindable).InvalidateLayout();
            ((MultiCardHolder)bindable).InvalidateMeasure();
        }

        public List<FeaturedItem> Items {
            get {
                return (List<FeaturedItem>)GetValue(ItemsProperty);
            }

            set {
                SetValue(ItemsProperty, value);
                OnPropertyChanged("Items");
            }
        }
    }
}
