using CorporateMessaging.Infrastructure;

namespace CorporateMessaging.Tests.Fake;

internal sealed class FakeOutput : IOutput
{
    public List<string> Lines { get; } = new();

    public void Write(string text) => Lines.Add(text);
}