namespace Concurrency.ConsoleApp;

public sealed class Example_26 : IExample
{
    public async Task MainAsync()
    {
        var tcs = new TaskCompletionSource(); // options.
        var tcs2 = new TaskCompletionSource();

        _ = Task.Run(async () =>
        {
            IExample.Write("Inside background thread. Waiting for 5 seconds.");

            await Task.Delay(5000);

            IExample.Write("Finished waiting in background thread. Setting the first TCS.");
            tcs.SetResult();

            IExample.Write("Setting the second tcs");
            tcs2.SetResult();

            IExample.Write("Exiting the background thread");
        });

        IExample.Write("Waiting for tcs task to complete");
        await tcs.Task;

        IExample.Write("TCS task is finished.");
        IExample.Write("Waiting for TCS2 task to complete synchronously");
        tcs2.Task.Wait();
        //await tcs2.Task;

        IExample.Write("TCS2 is also finished. Exiting the app");

        Console.ReadLine();
    }
}
