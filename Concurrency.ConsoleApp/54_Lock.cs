namespace Concurrency.ConsoleApp;

public sealed class Example_54 : IExample
{
    private readonly object _lock = new();

    public void Main()
    {
        // Framework calls our sync method.
        Task.Run(SyncMethod);
        Task.Run(SyncMethod);
        Task.Run(SyncMethod);
        Task.Run(SyncMethod);

        Console.ReadLine();
    }

    public void SyncMethod()
    {
        Monitor.Enter(_lock);
        try
        {
            // Do our code.
            Thread.Sleep(10000);
        }
        finally
        {
            Monitor.Exit(_lock);
        }
    }

    public void SyncMethod2()
    {
        lock (_lock)
        {
            // Do our code.
            Thread.Sleep(10000);
        }
    }
}
