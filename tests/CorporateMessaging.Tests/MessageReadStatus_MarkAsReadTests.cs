using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;

using Xunit;

namespace CorporateMessaging.Tests;

public class MessageReadStatus_MarkAsReadTests
{
    [Fact]
    public void FirstMarkAsRead_SetsRead()
    {
        var user = new UserRecipient();
        var msg = new Message("S", "B", Importance.Low);
        user.Receive(msg);

        user.MarkAsRead(msg);

        MessageReceipt receipt = user.Inbox.First(r => ReferenceEquals(r.Message, msg));
        Assert.True(receipt.IsRead);
    }
}