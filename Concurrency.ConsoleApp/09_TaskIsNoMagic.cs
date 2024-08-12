namespace Concurrency.ConsoleApp;

public sealed class Example_9 : IExample
{
    public void Main()
    {
        var task = Method1Async();

        IExample.Write("Main method got task from method 1. Gonna wait on it.");

        task.Wait();
        IExample.Write("Waited. Exiting.");
        Console.ReadLine();
    }

    private Task Method1Async()
    {
        IExample.Write("Synchronously inside method 1.");

        var task = Task.Run(() =>
        {
            Thread.Sleep(1000);
            IExample.Write("Hello from background thread.");
        });

        Thread.Sleep(2000);
        IExample.Write("Synchronously after created task.");

        return task;
    }
}
