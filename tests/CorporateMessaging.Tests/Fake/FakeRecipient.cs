using CorporateMessaging.Messages;
using CorporateMessaging.Recipients;

namespace CorporateMessaging.Tests.Fake;

internal sealed class FakeRecipient : IRecipient
{
    public int ReceiveCalls { get; private set; }

    public Message? LastMessage { get; private set; }

    public void Receive(Message message)
    {
        ReceiveCalls++;
        LastMessage = message;
    }
}