using Showmie.Utils;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Showmie.ViewModels
{
    public class NotificationsVM
    {
        private ObservableCollection<Notification> ItemsList { get; set; } = new ObservableCollection<Notification>();

        public async Task<ObservableCollection<Notification>> GetItems()
        {
            var Notifications = new ObservableCollection<Notification>
            {
                new DesignNotification(2741, Notification.Type.Like, 93, 93, 25, new DateTime(2017,8,25), "testr_1 liked your design", 0),
                new DesignNotification(2741, Notification.Type.Like, 93, 129, 25, new DateTime(2017,8,25), "testr_1 liked your design", 0)
            };

            ItemsList = await new NotificationService().GetNotificationsAsync(App.CurrentUser.Id);
            return ItemsList;
        }

        //public int NoOfBoards()
        //{
        //    return BoardsList.Count;
        //}
    }
}
