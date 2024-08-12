namespace Concurrency.ConsoleApp;

public sealed class Example_59 : IExample
{
    // Advanced: Volatile, Thread.MemoryBarrier, Thread.Abort, Thread.Interrupt
    public void Main()
    {
        var value = 10;

        var i = 0;
        while (i < 1000)
        {
            i++;
            Task.Run(async () =>
            {
                await Task.Delay(1000);

                value++;
                //Interlocked.Add(ref value, 1);
                /*Interlocked.Exchange(ref value, 20);
                Interlocked.CompareExchange(ref value, 20, 10);
                var newValue = Interlocked.Increment(ref value);*/
            });
        }

        Thread.Sleep(2000);
        Console.WriteLine(value);

        Console.ReadLine();
    }
}
