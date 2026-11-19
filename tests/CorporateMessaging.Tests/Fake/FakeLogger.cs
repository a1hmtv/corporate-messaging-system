using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;

namespace CorporateMessaging.Tests.Fake;

internal sealed class FakeLogger : ILogger
{
    public int LogCalls { get; private set; }

    public Message? LastMessage { get; private set; }

    public void Log(Message message)
    {
        LogCalls++;
        LastMessage = message;
    }
}