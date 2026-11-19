using CorporateMessaging.Archivers;
using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public class ArchiverRecipient : IRecipient
{
    private readonly IMessageArchiver _archiver;

    public ArchiverRecipient(IMessageArchiver archiver)
    {
        ArgumentNullException.ThrowIfNull(archiver);
        _archiver = archiver;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _archiver.Save(message);
    }
}