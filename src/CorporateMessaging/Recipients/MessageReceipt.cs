using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public enum ReadStatus
{
    Unread,
    Read,
}

public class MessageReceipt
{
    public Message Message { get; }

    public bool IsRead { get; private set; }

    public MessageReceipt(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        Message = message;
        IsRead = false;
    }

    public void ChangeStatus()
    {
        if (IsRead)
        {
            throw new InvalidOperationException("The message has already been read!");
        }

        IsRead = true;
    }
}