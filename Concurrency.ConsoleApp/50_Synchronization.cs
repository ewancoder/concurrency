namespace Concurrency.ConsoleApp;

public sealed class Example_50 : IExample
{
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
        await Task.Delay(500);
        _generatedGuids.Add(Guid.NewGuid());
    }
}
