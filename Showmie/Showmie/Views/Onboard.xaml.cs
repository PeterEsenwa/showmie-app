using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms.Xaml;

namespace Showmie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Onboard : INotifyPropertyChanged
    {
        public Onboard()
        {
            InitializeComponent();
            BoardsSource = new OnboardsVM().GetBoards();
            SourceImage = 0;
            BindingContext = this;

        }

        public List<SingleBoard> BoardsSource { get; set; }
        private int _sourceImage;
        public int SourceImage { get { return _sourceImage; } set { _sourceImage = value; OnPropertyChanged(); } }
    }
}