using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExplorePage : TabbedPage
    {
		public ExplorePage ()
        {
            Color tabColorDefault = (Color)Xamarin.Forms.Application.Current.Resources["TabColorDefault"];
            Color tabBGColorDefault = (Color)Xamarin.Forms.Application.Current.Resources["TabBGColorDefault"];
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetBarItemColor(this, tabColorDefault);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSmoothScrollEnabled(this, true);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetIsSwipePagingEnabled(this, false);
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.TabbedPage.SetOffscreenPageLimit(this, 4);
            BarBackgroundColor = tabBGColorDefault;
            
            InitializeComponent ();
            //var titleView = new SearchBar { HeightRequest = 44, WidthRequest = 300, BackgroundColor= Color.Beige };
            //NavigationPage.SetTitleView(this, titleView);
        }
	}
}