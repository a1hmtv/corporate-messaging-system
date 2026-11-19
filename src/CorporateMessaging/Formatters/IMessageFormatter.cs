using CorporateMessaging.Messages;

namespace CorporateMessaging.Formatters;

public interface IMessageFormatter
{
    string Format(Message message);
}