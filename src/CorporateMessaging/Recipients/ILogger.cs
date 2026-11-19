using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public interface ILogger
{
    void Log(Message message);
}