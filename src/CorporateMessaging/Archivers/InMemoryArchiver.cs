using CorporateMessaging.Messages;

namespace CorporateMessaging.Archivers;

public class InMemoryArchiver : IMessageArchiver
{
    private readonly List<Message> _messages = new List<Message>();

    public void Save(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        _messages.Add(message);
    }

    public IReadOnlyList<Message> Messages => _messages.AsReadOnly();

    public void Clear()
    {
        _messages.Clear();
    }
}