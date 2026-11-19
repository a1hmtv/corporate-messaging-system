using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;

namespace CorporateMessaging.Topics;

public class Topic
{
    public string Name { get; }

    private readonly List<IRecipient> _recipients;

    public Topic(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        Name = name;
        _recipients = new List<IRecipient>();
    }

    public void AddRecipient(IRecipient recipient)
    {
        ArgumentNullException.ThrowIfNull(recipient);

        _recipients.Add(recipient);
    }

    public void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        foreach (IRecipient recipient in _recipients)
        {
            recipient.Receive(message);
        }
    }
}