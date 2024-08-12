namespace Concurrency.ConsoleApp;

public sealed class Example_968 : IExample
{
    public void Main()
    {
        using var cts = new CancellationTokenSource();

        var task1 = Task.Run(async () => await Task.Delay(10000));

        var task2 = task1.ContinueWith(_ => Console.WriteLine("Task 2"), cts.Token);
        //var task2 = task1.ContinueWith(_ => Console.WriteLine("Task 2"), cts.Token, TaskContinuationOptions.LazyCancellation, TaskScheduler.Default);

        var task3 = task2.ContinueWith(_ => Console.WriteLine("Task 3"));
        //var task3 = task2.ContinueWith(_ => Console.WriteLine("Task 3"), TaskContinuationOptions.OnlyOnRanToCompletion);

        Console.ReadLine();
        cts.Cancel();
        try { task1.Wait(); } catch { }

        Console.WriteLine("Finished task1");
        Console.ReadLine();
    }
}
