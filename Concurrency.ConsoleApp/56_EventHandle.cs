namespace Concurrency.ConsoleApp;

public sealed class Example_56 : IExample
{
    public void Main()
    {
        // WaitHandle, EventHandle, ManualResetEvent, AutoResetEvent, CountdownEvent
        using var manualResetEvent = new ManualResetEvent(initialState: false);

        Task.Run(() =>
        {
            Thread.Sleep(2000);
            manualResetEvent.Set();
        });

        manualResetEvent.WaitOne();
        Console.WriteLine("Done");
        manualResetEvent.WaitOne();
        Console.WriteLine("Done");

        Console.ReadLine();
    }
}
