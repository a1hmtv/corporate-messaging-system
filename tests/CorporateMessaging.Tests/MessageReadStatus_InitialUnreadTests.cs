using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;

using Xunit;

namespace CorporateMessaging.Tests;

public class MessageReadStatus_InitialUnreadTests
{
    [Fact]
    public void AfterReceive_MessageIsUnread()
    {
        var user = new UserRecipient();
        var msg = new Message("Subject", "Body", Importance.Medium);

        user.Receive(msg);

        MessageReceipt receipt = user.Inbox.First(r => ReferenceEquals(r.Message, msg));
        Assert.False(receipt.IsRead);
    }
}