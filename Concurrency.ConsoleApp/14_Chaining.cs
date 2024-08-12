namespace Concurrency.ConsoleApp;

// Next chapter async/await
public sealed class Example_14 : IExample
{
    public void Main()
    {
        BlockingCode();

        //NonBlockingCode();

        IExample.Write("Done doing main");

        Console.ReadLine();
    }

    public void BlockingCode()
    {
        var blockingTask = Task.Run(() => Thread.Sleep(TimeSpan.FromHours(1)));

        blockingTask.Wait();

        IExample.Write("Done");
    }

    public void NonBlockingCode()
    {
        var nonblockingTask = Task.Delay(TimeSpan.FromHours(1));

        nonblockingTask.Wait();
        IExample.Write("Done from nonblocking code");

        /*var newTask = nonblockingTask.ContinueWith(previousCompletedTask =>
        {
            IExample.Write("Done from nonblocking code");
        });*/
    }

    public async Task NonBlockingCodeAsync()
    {
        var nonBlockingTask = Task.Delay(TimeSpan.FromHours(1));

        await nonBlockingTask;

        IExample.Write("Done from nonblocking code");
    }
}
