namespace Concurrency.ConsoleApp;

public sealed class Example_15 : IExample
{
    public void Main()
    {
        var tcs = new TaskCompletionSource();

        using var timer = new Timer(_ =>
        {
            tcs.SetResult();
        }, null, 5000, -1);

        tcs.Task.Wait();
        Console.WriteLine("Done 1");



        // The same but naive.
        var tcs2 = new TaskCompletionSource();

        Task.Run(async () =>
        {
            var i = 0;
            while (i < 50)
            {
                await Task.Delay(100);
                i++;
            }

            tcs2.SetResult();
        });

        tcs2.Task.Wait();
        Console.WriteLine("Done 2");

        Console.ReadLine();
    }
}
