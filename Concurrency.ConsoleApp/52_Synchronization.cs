namespace Concurrency.ConsoleApp;

public sealed class Example_52 : IExample
{
    private readonly SemaphoreSlim _lock = new(1, 1);
    List<Guid> _generatedGuids = [];

    public void Main()
    {
        var tasks = Enumerable.Range(1, 1000)
            .Select(_ => Generate())
            .ToList();

        Task.WaitAll([..tasks]);
        Console.WriteLine("Done!");

        Console.ReadLine();
    }

    private async Task Generate()
    {
        await _lock.WaitAsync();

        //await Task.Delay(500); // Comment out.
        _generatedGuids.Add(Guid.NewGuid());
        throw new InvalidOperationException(); // Simulate Add throwing an exception.

        _lock.Release();
    }
}
