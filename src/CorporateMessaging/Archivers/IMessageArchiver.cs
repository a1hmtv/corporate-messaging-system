using CorporateMessaging.Messages;

namespace CorporateMessaging.Archivers;

public interface IMessageArchiver
{
    void Save(Message message);
}