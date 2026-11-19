namespace CorporateMessaging.Messages;

public enum Importance
{
    Low,
    Medium,
    High,
}

public record Message
{
    public string Title { get; }

    public string Body { get; }

    public Importance Importance { get; }

    public Message(string title, string body, Importance importance = Importance.Low)
    {
        Title = title;
        Body = body;
        Importance = importance;
    }
}