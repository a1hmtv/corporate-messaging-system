using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;
using CorporateMessaging.Tests.Fake;

using Xunit;

namespace CorporateMessaging.Tests;

public class FilteredRecipient_LowBlockedTests
{
    [Fact]
    public void BelowMinImportance_DoesNotReachInner()
    {
        var inner = new FakeRecipient();
        var sut = new ImportanceProxy(inner, Importance.High);

        var msg = new Message("Info", "Low", Importance.Medium);
        sut.Receive(msg);

        Assert.Equal(0, inner.ReceiveCalls);
        Assert.Null(inner.LastMessage);
    }
}