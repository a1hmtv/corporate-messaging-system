using CorporateMessaging.Messages;

namespace CorporateMessaging.Alerts;

public interface IAlertSystem
{
    void Notify(Message message);
}