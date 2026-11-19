using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public interface IRecipient
{
    void Receive(Message message);
}