using CorporateMessaging.Archivers;
using CorporateMessaging.Messages;
using CorporateMessaging.Tests.Fake;

using Xunit;

namespace CorporateMessaging.Tests;

public class FormattingArchiver_BasicTests
{
    [Fact]
    public void Save_CallsFormatter_And_WritesFormatted()
    {
        var formatter = new FakeFormatter { ReturnText = "[Formatted]" };
        var output = new FakeOutput();
        var sut = new FormattingArchiver(formatter, output);

        var msg = new Message("T", "B", Importance.High);
        sut.Save(msg);

        Assert.Equal(1, formatter.FormatCalls);
        Assert.Same(msg, formatter.LastMessage);
        Assert.Single(output.Lines);
        Assert.Equal("[Formatted]", output.Lines[0]);
    }
}