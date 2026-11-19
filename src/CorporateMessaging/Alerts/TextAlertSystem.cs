using CorporateMessaging.Infrastructure;
using CorporateMessaging.Messages;

namespace CorporateMessaging.Alerts;

public class TextAlertSystem : IAlertSystem
{
    private readonly IOutput _output;
    private readonly string _alertText;

    public TextAlertSystem(IOutput output, string alertText = "⚠️ Suspicious message found ⚠️")
    {
        ArgumentNullException.ThrowIfNull(output);
        _output = output;
        _alertText = alertText;
    }

    public void Notify(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _output.Write($"{_alertText}\nСообщение: {message.Title}");
    }
}