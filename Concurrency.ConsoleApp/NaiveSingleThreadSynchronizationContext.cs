using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

internal sealed class NaiveSingleThreadSynchronizationContext : SynchronizationContext
{
    private readonly ConcurrentQueue<Action> _queue = new();

    public NaiveSingleThreadSynchronizationContext()
    {
        _ = Task.Run(() =>
        {
            while (true)
            {
                if (_queue.TryDequeue(out var action))
                    action();

                Thread.Sleep(10);
            }
        });
    }

    public override void Post(SendOrPostCallback d, object? state)
    {
        _queue.Enqueue(() => d?.Invoke(state));
    }
}
