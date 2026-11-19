using CorporateMessaging.Infrastructure;
using CorporateMessaging.Messages;

namespace CorporateMessaging.Alerts;

public class SoundAlertSystem : IAlertSystem
{
    private readonly IBeep _beep;
    private readonly IOutput _output;

    public SoundAlertSystem(IBeep beep, IOutput output)
    {
        ArgumentNullException.ThrowIfNull(beep);

        ArgumentNullException.ThrowIfNull(output);

        _beep = beep;
        _output = output;
    }

    public void Notify(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _beep.Beep();
        _output.Write("🔔 The sound alert worked!");
    }
}