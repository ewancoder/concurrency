namespace Concurrency.ConsoleApp;

public sealed class Example_13 : IExample
{
    public void Main()
    {
        using var cts = new CancellationTokenSource();
        Task.Delay(TimeSpan.FromMinutes(1)).ContinueWith(_ => cts.Cancel());

        GoodImplementedMethodAsync(cts.Token).Wait();
        Console.WriteLine("Done");

        Console.ReadLine();
    }

    public Task GoodImplementedMethodAsync(CancellationToken cancellationToken)
    {
        long i = 1;

        while (true)
        {
            i++;
            if (i > 100_000_000)
                i = 1;

            //cancellationToken.ThrowIfCancellationRequested();

            /*if (i % 10_000 == 0)
                cancellationToken.ThrowIfCancellationRequested();*/
        }
    }
}
