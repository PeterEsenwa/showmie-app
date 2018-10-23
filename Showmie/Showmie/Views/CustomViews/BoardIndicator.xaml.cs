
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoardIndicator : Grid
    {
        public BoardIndicator()
        {
            InitializeComponent();
        }

    }
    public class IndicatorImage : Image
    {
        public IndicatorImage()
        {

        }

        
    }

}