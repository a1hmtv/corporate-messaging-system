using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public class GroupRecipient : IRecipient
{
    private readonly List<IRecipient> _recipients = new();

    public IReadOnlyList<IRecipient> Recipients => _recipients.AsReadOnly();

    public void Add(IRecipient recipient)
    {
        ArgumentNullException.ThrowIfNull(recipient);

        _recipients.Add(recipient);
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        foreach (IRecipient r in _recipients)
        {
            r.Receive(message);
        }
    }
}