using CorporateMessaging.Alerts;
using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public enum AlertTriggerMode
{
    OnSuspicious,
    Always,
}

public class AlertRecipient : IRecipient
{
    private readonly IAlertSystem _alertSystem;
    private readonly AlertTriggerMode _mode;
    private readonly HashSet<string> _keywords;
    private readonly IRecipient _inner;

    public AlertRecipient(
        IAlertSystem alertSystem,
        AlertTriggerMode mode,
        IEnumerable<string> keywords,
        IRecipient inner)
    {
        ArgumentNullException.ThrowIfNull(alertSystem);
        ArgumentNullException.ThrowIfNull(keywords);
        ArgumentNullException.ThrowIfNull(inner);

        _alertSystem = alertSystem;
        _mode = mode;
        _inner = inner;

        _keywords = new HashSet<string>(
            keywords.Where(word => !string.IsNullOrWhiteSpace(word)),
            StringComparer.OrdinalIgnoreCase);
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (_mode == AlertTriggerMode.Always || ContainsAnyKeyword(message))
        {
            _alertSystem.Notify(message);
        }

        _inner.Receive(message);
    }

    private bool ContainsAnyKeyword(Message message)
    {
        return _keywords.Any(keyword =>
            message.Title?.Contains(
                keyword, StringComparison.OrdinalIgnoreCase) == true ||
            message.Body?.Contains(
                keyword, StringComparison.OrdinalIgnoreCase) == true);
    }
}