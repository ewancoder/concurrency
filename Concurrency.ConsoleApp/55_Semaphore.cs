namespace Concurrency.ConsoleApp;

public sealed class Example_55 : IExample
{
    // System-wide.
    private readonly Semaphore _semaphore = new(2, 2, "MySemaphore");
    //private readonly Mutex _mutex = new(false, "MySemaphore");

    public void Main()
    {
        while (true)
        {
            Task.Run(DoWork);
            Console.ReadLine();
        }
    }

    private void DoWork()
    {
        _semaphore.WaitOne();
        //_mutex.WaitOne();

        try
        {
            Console.WriteLine("Entered lock in DoWork. Waiting for 5 seconds.");
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }
        finally
        {
            _semaphore.Release();
            //_mutex.ReleaseMutex();
        }
    }
}
