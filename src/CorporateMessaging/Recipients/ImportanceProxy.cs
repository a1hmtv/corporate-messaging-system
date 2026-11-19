using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public class ImportanceProxy : IRecipient
{
    private readonly IRecipient _real;
    private readonly Importance _minImportance;

    public ImportanceProxy(IRecipient real, Importance minImportance)
    {
        ArgumentNullException.ThrowIfNull(real);
        _real = real;
        _minImportance = minImportance;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.Importance < _minImportance) return;

        _real.Receive(message);
    }
}