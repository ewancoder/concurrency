namespace Concurrency.ConsoleApp;

public sealed class Example_57 : IExample
{
    private readonly ReaderWriterLockSlim _rwls = new();

    public void Main()
    {
        Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(5);
                Task.Run(() =>
                {
                    _rwls.EnterReadLock();
                    try
                    {
                        Console.WriteLine($"READER Inside lock - {DateTime.UtcNow}");
                        Thread.Sleep(10);
                    }
                    finally
                    {
                        _rwls.ExitReadLock();
                    }
                });
            }
        });

        Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(10000);
                Task.Run(() =>
                {
                    _rwls.EnterWriteLock();
                    try
                    {
                        Console.WriteLine($">>> WRITER <<< lock - {DateTime.UtcNow}");
                        Thread.Sleep(1000);
                    }
                    finally
                    {
                        _rwls.ExitWriteLock();
                    }
                });
            }
        });

        Console.ReadLine();
    }
}
