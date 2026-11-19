using CorporateMessaging.Messages;

namespace CorporateMessaging.Formatters;

public class ConsoleFormatter : IMessageFormatter
{
    public string Format(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        string color = "⚪";
        if (message.Importance == Importance.Low)
            color = "🟢";
        else if (message.Importance == Importance.Medium)
            color = "🟡";
        else if (message.Importance == Importance.High)
            color = "🔴";

        string formatted =
            $"\u001b[3m# {message.Title}\u001b[0m\n" +
            $"Importance: {color} {message.Importance} {color}\n" +
            $"{message.Body}\n";

        return formatted;
    }
}