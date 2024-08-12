using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class Example_9992 : IExample, IDisposable
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    private readonly List<string> _processedNames = new();
    private readonly BlockingCollection<string> _names = new(5);

    public void Dispose()
    {
        _lock.Dispose();
        _names.Dispose();
    }

    public void Main()
    {
        _ = Task.Run(ProcessNames);
        _ = Task.Run(ProcessNames);
        _ = Task.Run(ProcessNames);

        while (true)
        {
            var name = Console.ReadLine();
            if (name == "print")
                _ = ReadAndClearNamesAsync();
            else
                _names.Add(name!);
        }
    }

    private async Task ProcessNames()
    {
        var someVar = Guid.NewGuid();
        foreach (var name in _names.GetConsumingEnumerable())
        {
            await _lock.WaitAsync();
            try
            {
                _processedNames.Add($"Processed {name}");
                await Task.Delay(5000);
            }
            finally
            {
                _lock.Release();
            }
        }
    }

    private async Task ReadAndClearNamesAsync()
    {
        await _lock.WaitAsync();
        try
        {
            var adornedNames = _processedNames.ToAsyncEnumerable()
                .SelectAwait(async name =>
                {
                    await Task.Delay(1000);
                    return $"Adorned {name}";
                });

            await foreach (var name in adornedNames)
            {
                Console.WriteLine(name);
            }
        }
        finally
        {
            _lock.Release();
        }
    }
}
