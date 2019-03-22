using Showmie.ViewModels;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Showmie.Views.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        public ObservableCollection<Notification> NotificationsSource { get; set; }
        private NotificationsVM notificationsVM = new NotificationsVM();

        public NotificationsPage()
        {
            InitializeComponent();
            BindingContext = this;
            //MyListView.ItemsSource = Notifications;
        }

        protected override void OnAppearing()
        {
            LoadNotifications();
            MyListView.SetBinding(ListView.ItemsSourceProperty, "NotificationsSource");
            base.OnAppearing();
        }

        public async void LoadNotifications()
        {
            NotificationsSource = await notificationsVM.GetItems();
        }

        private async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
