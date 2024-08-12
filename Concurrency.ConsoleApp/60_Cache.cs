namespace Concurrency.ConsoleApp;

public sealed class Example_60 : IExample
{
    public void Main()
    {
        for (var i = 0; i < 10; i++)
        {
            Task.Run(GetValueAsync);
        }

        Console.ReadLine();
    }

    private string? _cachedValue;
    private readonly SemaphoreSlim _lock = new(1, 1);

    private async Task<string> GetValueAsync()
    {
        if (_cachedValue != null)
            return _cachedValue;

        await _lock.WaitAsync();
        try
        {
            if (_cachedValue != null)
                return _cachedValue;

            Console.WriteLine("Getting value");
            await Task.Delay(2000); // Get value.
            _cachedValue = "value";
            return _cachedValue;
        }
        finally
        {
            _lock.Release();
        }
    }
}
