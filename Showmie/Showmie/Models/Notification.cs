using System;

public struct Notification
{
    public int Priority { get; set; }
    public string Title { get; set; }
    public string Detail { get; set; }
    public bool Seen { get; set; }

    public Notification(int priority, string title, string detail, bool seen) : this()
    {
        Priority = priority;
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Detail = detail ?? throw new ArgumentNullException(nameof(detail));
        Seen = seen;
    }
}