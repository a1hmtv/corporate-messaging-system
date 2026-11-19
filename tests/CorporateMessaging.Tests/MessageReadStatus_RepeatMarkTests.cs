using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;

using Xunit;

namespace CorporateMessaging.Tests;

public class MessageReadStatus_RepeatMarkTests
{
    [Fact]
    public void SecondMarkAsRead_Throws()
    {
        var user = new UserRecipient();
        var msg = new Message("S", "B", Importance.Low);
        user.Receive(msg);
        user.MarkAsRead(msg);

        Assert.Throws<InvalidOperationException>(() => user.MarkAsRead(msg));
    }
}