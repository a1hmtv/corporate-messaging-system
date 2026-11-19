using CorporateMessaging.Formatters;
using CorporateMessaging.Messages;

namespace CorporateMessaging.Tests.Fake;

internal sealed class FakeFormatter : IMessageFormatter
{
    public int FormatCalls { get; private set; }

    public Message? LastMessage { get; private set; }

    public string ReturnText { get; set; } = "[Formatted]";

    public string Format(Message message)
    {
        FormatCalls++;
        LastMessage = message;
        return ReturnText;
    }
}