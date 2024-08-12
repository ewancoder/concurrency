using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class MessageProcessor
{
    private readonly ConcurrentQueue<string> _messages;

    public MessageProcessor()
    {
        _messages = new();
    }

    public IEnumerable<string> GetMessagesSnapshot()
        => _messages.ToList();

    public async Task ProcessInFiveSecondsAsync(string message)
    {
        await Task.Delay(TimeSpan.FromSeconds(5));

        _messages.Enqueue(message);
    }
}
