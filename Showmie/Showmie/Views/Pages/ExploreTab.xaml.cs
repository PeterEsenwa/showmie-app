using Showmie.Models;
using Showmie.Utils;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExploreTab : ContentPage
    {

        public ExploreTab()
        {
            InitializeComponent();
            BindingContext = this;
            //CoordinatorPage coordinatorPage = new CoordinatorPage(FilterItems);
            //Button Clicker = new Button() { Text = "Click bait" };
            //Clicker.Clicked += Clicker_Clicked;
            //coordinatorPage.Children.Add(Clicker);
            //ExploreCardHolder item = new ExploreCardHolder() { BackgroundColor = Color.Chocolate };
            //ExploreCardHolder item2 = new ExploreCardHolder() { BackgroundColor = Color.Chocolate };
            //ExploreCardHolder item3 = new ExploreCardHolder() { BackgroundColor = Color.Chocolate };
            //Grid content = new Grid();
            //content.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.05, GridUnitType.Star) });
            //content.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            //content.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(0.05, GridUnitType.Star) });
            //content.Children.Add(item,1,0);
            //content.Children.Add(item2,1,1);
            //content.Children.Add(item3,1,2);
            //coordinatorPage.Children.Add(new ScrollView() { Content=content });
            //Content = coordinatorPage;
        }

        public List<DesignGroup> RecentDesigns { get; private set; }
        public List<DesignGroup> MostLikedDesigns { get; private set; }
        public List<DesignGroup> MostRequestedDesigns { get; private set; }

        public int CompareIntegers(int x, int y)
        {
            if (x == y)
                return 0;
            else if (x > y)
                return y - x;
            else if (x < y)
                return x - y;
            else return 0;
        }

        protected override async void OnAppearing()
        {

            if (RecentDesigns == null || RecentDesigns.Count == 0)
            {
                DesignService service = new DesignService();

                RecentDesigns = await service.GetDesigns(Title);
                RecentDesigns.ForEach((designGroup) => 
                {
                    string URL = designGroup.Design.Image;
                    int uploadIndex = URL.IndexOf("upload/") + 7;
                    URL = URL.Insert(uploadIndex, "w_0.75,h_0.75,c_crop,g_auto,q_auto/w_180/");
                    designGroup.Design.Image = URL;
                });
                MostLikedDesigns = RecentDesigns;
                MostRequestedDesigns = RecentDesigns;
                RecentDesignsViewer.ItemsSource = RecentDesigns;

                MostLikedDesigns.Sort(new Comparison<DesignGroup>((x, y) => CompareIntegers(x.Design.Likes, y.Design.Likes)));
                MostLikedDesignsViewer.ItemsSource = MostRequestedDesigns;
            }

            base.OnAppearing();
        }

        private int CompareIntegers(int? x, int? y)
        {
            if (x.HasValue && y.HasValue)
            {
                if (x.Value == y.Value)
                    return 0;
                else if (x.Value > y.Value)
                    return -1;
                else if (x < y)
                    return 1;
            }
            else if (x.HasValue)
            {
                return -1;
            }
            else if (y.HasValue)
            {
                return 1;
            }
            else if (!x.HasValue && !y.HasValue)
            {
                return 0;
            }
            return 0;
        }
    }
}