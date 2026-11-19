using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;
using CorporateMessaging.Tests.Fake;
using CorporateMessaging.Topics;

using Xunit;

namespace CorporateMessaging.Tests;

public class Topic_FilterScenarioTests
{
    [Fact]
    public void TwoRecipients_OneFiltered_LowImportance_DeliveredOnce()
    {
        var singleUser = new FakeRecipient();
        var filtered = new ImportanceProxy(singleUser, Importance.High);

        var topic = new Topic("Group");
        topic.AddRecipient(filtered);
        topic.AddRecipient(singleUser);

        var low = new Message("N", "low", Importance.Low);
        topic.Send(low);

        Assert.Equal(1, singleUser.ReceiveCalls);
        Assert.Same(low, singleUser.LastMessage);
    }
}