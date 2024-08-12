namespace Concurrency.ConsoleApp;

public sealed class Example_11 : IExample
{
    public void Main()
    {
        using var cts = new CancellationTokenSource();

        var longRunningTask = DoSomeVeryLongDBQueryAsync();

        //var delayTask = Task.Delay(TimeSpan.FromMinutes(1));
        //var delayTask = Task.Run(() => Thread.Sleep(TimeSpan.FromMinutes(1)));

        //var delayTask = Task.Delay(Timeout.Infinite);
        //var delayTask = Task.Delay(Timeout.Infinite, cts.Token);

        //Task.WaitAny(longRunningTask, delayTask);
        /*var task = Task.WhenAny(longRunningTask, delayTask);

        Console.ReadLine();
        cts.Cancel();

        task.Wait();
        Console.WriteLine("Done!");
        Console.WriteLine(task.Status);*/

        Console.ReadLine();
    }

    private Task DoSomeVeryLongDBQueryAsync()
    {
        return Task.Run(() =>
        {
            Thread.Sleep(TimeSpan.FromHours(5));
        });
    }
}
