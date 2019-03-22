using Showmie.Models;
using Showmie.Utils;
using System;
using System.ComponentModel;

public class Notification
{
    public int ID { get; set; }
    public Type NotificationType { get; set; }
    public int ReceiverId { get; set; }
    public int SenderId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int IsRead { get; set; }
    public User Sender { get; set; }

    public Notification()
    {
    }

    public Notification(int iD, Type notificationType, int receiverId, int senderId, DateTime createdAt, string title, string description, int isRead)
        : this(iD, notificationType, receiverId, senderId, createdAt, title, isRead)
    {
        Description = description ?? throw new ArgumentNullException(nameof(description));
    }

    public Notification(int iD, Type notificationType, int receiverId, int senderId, DateTime createdAt, string title, int isRead)
    {
        ID = iD;
        NotificationType = notificationType;
        ReceiverId = receiverId;
        SenderId = senderId;
        CreatedAt = createdAt;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        IsRead = isRead;
        //GetSender();
    }

    //public async void GetSender()
    //{
    //    if (SenderId != 0)
    //    {
    //        UserService userService = new UserService();
    //        Sender = await userService.GetUserAsync(SenderId);
    //    }
    //}

    public enum Type
    {
        Like = 0,
        Comment = 1,
        Collect = 2,
        Follow = 3,
        Request = 4,
        Admin = 5
    }
}

public class DesignNotification : Notification, INotifyPropertyChanged
{
    //private Design _design;

    public Design Design { get; set; }
    public int DesignId { get; set; }
    //public Design Design {
    //    get => _design;

    //    set {
    //        _design = value;
    //        OnPropertyChanged("Design");
    //    }
    //}

    public DesignNotification()
    {
    }

    public DesignNotification(int iD, Type notificationType, int receiverId, int senderId, int designId, DateTime createdAt, string title, int isRead)
    {
        ID = iD;
        NotificationType = notificationType;
        ReceiverId = receiverId;
        SenderId = senderId;
        DesignId = designId;
        CreatedAt = createdAt;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        IsRead = isRead;
        GetDesign();
        GetSender();
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public async void GetSender()
    {
        if (SenderId != 0)
        {
            UserService userService = new UserService();
            Sender = await userService.GetUserAsync(SenderId);
        }
    }

    public async void GetDesign()
    {
        if (DesignId != 0)
        {
            DesignService service = new DesignService();
            Design = await service.GetDesign(DesignId);
        }
    }
}

public class EventNotification : Notification
{
    public int EventId { get; set; }

    public EventNotification()
    {
    }

    public EventNotification(int iD, Type notificationType, int receiverId, int senderId, int eventId, DateTime createdAt, string title, int isRead)
    {
        ID = iD;
        NotificationType = notificationType;
        ReceiverId = receiverId;
        SenderId = senderId;
        EventId = eventId;
        CreatedAt = createdAt;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        IsRead = isRead;
    }
}