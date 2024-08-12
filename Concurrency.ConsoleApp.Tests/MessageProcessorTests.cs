using Microsoft.Extensions.Time.Testing;

namespace Concurrency.ConsoleApp.Tests;

public class MessageProcessorTests
{
    private readonly Fixture _fixture = new();

    [Fact]
    public async Task ShouldAddMessage_InFiveSeconds()
    {
        var message = _fixture.Create<string>();

        var sut = new MessageProcessor();

        var task = sut.ProcessInFiveSecondsAsync(message);

        await Task.Delay(4500);
        Assert.DoesNotContain(message, sut.GetMessagesSnapshot());
        Assert.False(task.IsCompleted);

        await Task.Delay(500 + 20);
        Assert.Contains(message, sut.GetMessagesSnapshot());
        Assert.True(task.IsCompleted);
    }

    [Fact]
    public async Task ShouldAddMessage_InFiveSeconds_BetterTest()
    {
        var message = _fixture.Create<string>();

        var timeProvider = new FakeTimeProvider();

        var sut = new BetterMessageProcessor(timeProvider);

        var task = sut.ProcessInFiveSecondsAsync(message);

        timeProvider.Advance(TimeSpan.FromMilliseconds(4500));
        Assert.DoesNotContain(message, sut.GetMessagesSnapshot());
        Assert.False(task.IsCompleted);

        timeProvider.Advance(TimeSpan.FromMilliseconds(500));
        await Task.Delay(20);
        Assert.Contains(message, sut.GetMessagesSnapshot());
        Assert.True(task.IsCompleted);
    }
}
