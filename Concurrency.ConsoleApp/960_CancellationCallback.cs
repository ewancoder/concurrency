namespace Concurrency.ConsoleApp;

public sealed class Example_960 : IExample
{
    public void Main()
    {
        var cts = new CancellationTokenSource();

        using var registration = cts.Token.Register(() => Console.WriteLine("Cancellation requested."));
        cts.Token.Register(() => { Thread.Sleep(1000); Console.WriteLine("One more line."); });

        cts.Cancel();
        //await cts.CancelAsync();
        registration.Dispose();

        Console.ReadLine();
    }
}
