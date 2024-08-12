namespace Concurrency.ConsoleApp;

public sealed class Example_12 : IExample
{
    // Not important.
    public void Main()
    {
        using var cts = new CancellationTokenSource();

        OurMethodAsync(cts.Token).Wait();
        Console.WriteLine("Done");

        Console.ReadLine();
    }

    // External cancellationToken comes to us.
    private Task OurMethodAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            /*using var localCts = new CancellationTokenSource();
            using var combinedCts = CancellationTokenSource.CreateLinkedTokenSource(
                cancellationToken, localCts.Token);*/

            var longRunningTask = DoSomeVeryLongDBQueryAsync();

            var delayTask = Task.Delay(Timeout.Infinite, cancellationToken);
            //var delayTask = Task.Delay(Timeout.Infinite, combinedCts.Token);

            var task = Task.WhenAny(longRunningTask, delayTask);

            task.Wait();
            //localCts.Cancel(); // Cancel if DoSomeVeryLongDBQueryAsync finished first.
        });
    }

    private Task DoSomeVeryLongDBQueryAsync()
    {
        return Task.Run(() =>
        {
            Thread.Sleep(TimeSpan.FromHours(5));
        });
    }
}
