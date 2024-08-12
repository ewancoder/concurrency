using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class BetterMessageProcessor
{
    private readonly TimeProvider _timeProvider;
    private readonly ConcurrentQueue<string> _messages;

    public BetterMessageProcessor(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
        _messages = new();
    }

    public IEnumerable<string> GetMessagesSnapshot()
        => _messages.ToList();

    public async Task ProcessInFiveSecondsAsync(string message)
    {
        await Task.Delay(TimeSpan.FromSeconds(5), _timeProvider);

        _messages.Enqueue(message);
    }
}

