using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public class UserRecipient : IRecipient
{
    private readonly List<MessageReceipt> _inbox = new();

    public IReadOnlyList<MessageReceipt> Inbox => _inbox.AsReadOnly();

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _inbox.Add(new MessageReceipt(message));
    }

    public void MarkAsRead(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        MessageReceipt? receipt = _inbox.Find(
            r => ReferenceEquals(r.Message, message));

        if (receipt == null)
            throw new InvalidOperationException(
                "There is no such message in your inbox.");

        receipt.ChangeStatus();
    }
}