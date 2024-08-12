namespace Concurrency.ConsoleApp;

public sealed class Example_10 : IExample
{
    public void Main()
    {
        var cts = new CancellationTokenSource();
        //var cts = new CancellationTokenSource(TimeSpan.FromMinutes(1));

        var task = LongRunningOperationAsync(cts.Token);
        //var task = LongRunningOperationAsync(CancellationToken.None);
        //var task = LongRunningOperationAsync(default);

        Console.ReadLine();

        cts.Cancel();
        try
        {
            task.GetAwaiter().GetResult();
        }
        catch (OperationCanceledException exception)
        {
            Console.WriteLine("Cancelled.");
        }

        Console.WriteLine(task.Status);
        Console.ReadLine();
    }

    private Task LongRunningOperationAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(100);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }/*, cancellationToken*/);
    }
}
