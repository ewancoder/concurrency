namespace Concurrency.ConsoleApp;

public sealed class Example_965 : IExample
{
    public void Main()
    {
        string[] data = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"];

        var result = data
            .AsParallel()
            .WithDegreeOfParallelism(5)
            .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            .WithCancellation(default)
            .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
            .AsOrdered()
            .Select(x =>
            {
                Console.WriteLine($"Processing {x} on thread {Environment.CurrentManagedThreadId}");
                Thread.Sleep(1000);
                return x;
            })
            .ToList();

        Console.ReadLine();
    }
}
