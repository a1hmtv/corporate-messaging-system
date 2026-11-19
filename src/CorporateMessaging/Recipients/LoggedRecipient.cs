using CorporateMessaging.Messages;

namespace CorporateMessaging.Recipients;

public class LoggedRecipient : IRecipient
{
    private readonly IRecipient _inner;
    private readonly ILogger _logger;

    public LoggedRecipient(IRecipient inner, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(inner);
        ArgumentNullException.ThrowIfNull(logger);
        _inner = inner;
        _logger = logger;
    }

    public void Receive(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _logger.Log(message);
        _inner.Receive(message);
    }
}