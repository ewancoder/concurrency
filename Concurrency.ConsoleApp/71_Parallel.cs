namespace Concurrency.ConsoleApp;

public sealed class Example_71 : IExample
{
    public void Main()
    {
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = 2,
            CancellationToken = default,
            TaskScheduler = TaskScheduler.Default
        };

        // ForAsync
        Parallel.For(fromInclusive: 1, toExclusive: 11, options, index =>
        {
            Thread.Sleep(5000);

            Console.WriteLine(index);
        });

        Parallel.ForEach(Enumerable.Range(1, 10), options, index =>
        {
            Thread.Sleep(100);

            Console.WriteLine("Foreach: " + index);
        });

        Parallel.Invoke(
            () => Console.WriteLine(1),
            () => Console.WriteLine(2),
            () => Console.WriteLine(3));

        Console.ReadLine();
    }
}
