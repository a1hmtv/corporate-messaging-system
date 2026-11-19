using CorporateMessaging.Formatters;
using CorporateMessaging.Infrastructure;
using CorporateMessaging.Messages;

namespace CorporateMessaging.Archivers;

public class FormattingArchiver : IMessageArchiver
{
    private readonly IMessageFormatter _formatter;
    private readonly IOutput _output;

    public FormattingArchiver(IMessageFormatter formatter, IOutput output)
    {
        ArgumentNullException.ThrowIfNull(formatter);

        ArgumentNullException.ThrowIfNull(output);

        _formatter = formatter;
        _output = output;
    }

    public void Save(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        string formatted = _formatter.Format(message);

        if (string.IsNullOrWhiteSpace(formatted))
            throw new InvalidOperationException("Formatter returned empty result.");

        _output.Write(formatted);
    }
}