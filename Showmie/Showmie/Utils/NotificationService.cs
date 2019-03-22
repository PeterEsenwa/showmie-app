using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Essentials;

namespace Showmie.Utils
{

    internal class NotificationService : MyServices
    {
        //private ObservableCollection<Notification> NotificationsCollection { get; set; }

        public async Task<ObservableCollection<Notification>> GetNotificationsAsync(int userId)
        {
            // TODO: Create Utility function to assess networkAccess
            if (userId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userId));
            }

            switch (Connectivity.NetworkAccess)
            {
                case NetworkAccess.Internet:
                {
                    var uriString = string.Format(URLS.GetUserNotificationsByID, userId.ToString(), "all");
                    var uri = new Uri(uriString);

                    HttpResponseMessage response = await httpClient.GetAsync(uri);

                    if (!response.IsSuccessStatusCode) return null;

                    JObject respBody = JObject.Parse(await response.Content.ReadAsStringAsync());

                    if (!respBody.TryGetValue("body", out body) || !body.HasValues) return null;

                    var notifications = new ObservableCollection<Notification>();
                    foreach (JToken compoundNotification in body.Children())
                    {
                        var tempObject = compoundNotification.Value<JToken>("Notification");
                        var notification = JsonConvert.DeserializeObject<Notification>(tempObject.Value<JObject>().ToString());
                        Debug.WriteLine(notification);
                        notifications.Add(notification);
                    }

                    return notifications;
                }
                case NetworkAccess.Unknown:
                {
                    break;
                }
                case NetworkAccess.None:
                {
                    break;
                }
                case NetworkAccess.Local:
                {
                    break;
                }
                case NetworkAccess.ConstrainedInternet:
                {
                    break;
                }
                default:
                {
                    return null;
                }
            }

            return null;
        }
    }
}
