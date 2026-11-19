using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;
using CorporateMessaging.Tests.Fake;

using Xunit;

namespace CorporateMessaging.Tests;

public class LoggedRecipient_LogOnReceiveTests
{
    [Fact]
    public void Receive_Logs_And_Forwards()
    {
        var inner = new FakeRecipient();
        var logger = new FakeLogger();
        var sut = new LoggedRecipient(inner, logger);

        var msg = new Message("Event", "Body", Importance.Low);
        sut.Receive(msg);

        Assert.Equal(1, logger.LogCalls);
        Assert.Same(msg, logger.LastMessage);
        Assert.Equal(1, inner.ReceiveCalls);
        Assert.Same(msg, inner.LastMessage);
    }
}