using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Showmie.Utils
{
    public class NotificationTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NormalNotificationTemplate { get; set; }

        public DataTemplate DesignNotificationTemplate { get; set; }

        public DataTemplate EventNotificationTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (item)
            {
                case DesignNotification _:
                    return DesignNotificationTemplate;
                case EventNotification _:
                    return EventNotificationTemplate;
                default:
                    return NormalNotificationTemplate;
            }
        }
    }
}
