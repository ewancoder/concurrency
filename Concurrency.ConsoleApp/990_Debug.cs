using System.Data;

namespace Concurrency.ConsoleApp;

public sealed class Example_990 : IExample
{
    private int _index;

    public void Main()
    {
        _ = RunAsync();

        Console.ReadLine();
    }

    public async Task RunAsync()
    {
        while (true)
        {
            await Task.Delay(500);

            _ = DoWorkAsync(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }

    private async Task DoWorkAsync(string param1, string param2)
    {
        var work = new Work
        {
            Id = Guid.NewGuid(),
            Index = Interlocked.Increment(ref _index),
            Prop1 = Guid.NewGuid().ToString(),
            Prop2 = Guid.NewGuid().ToString(),
            Nested = new Work()
        };
        work.Nested.Prop1 = $"ivan-{work.Index}";

        await Task.Delay(1000);
        //Thread.Sleep(10000);

        IExample.Write($"Doing work {work.Id}");

        if (work.Index % 10 == 0)
            Thread.Sleep(5000);
        else
            await Task.Delay(5000);

        Task.Run(async () => await UpdateAsync(work));
    }

    private async Task UpdateAsync(Work work)
    {
        await Task.Delay(7000);
        work.Prop1 = Guid.NewGuid().ToString();

        IExample.Write("Value changed");
    }
}

class Work
{
    public Guid Id { get; set; }
    public int Index { get; set; }
    public string Prop1 { get; set; }
    public string Prop2 { get; set; }
    public Work Nested { get; set; }
}
