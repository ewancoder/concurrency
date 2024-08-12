using System.Diagnostics;

namespace Concurrency.ConsoleApp;

public sealed class Example_58 : IExample
{
    public void Main()
    {
        SpinLock _spinLock = new();
        SpinWait _spinWait = new();

        var lockTaken = false;

        _spinLock.Enter(ref lockTaken);
        Console.WriteLine(lockTaken);
        _spinLock.Exit();

        var sw = new Stopwatch();
        sw.Restart();
        _spinWait.SpinOnce();
        sw.Stop();
        Console.WriteLine(sw.Elapsed.Microseconds);

        Console.ReadLine();
    }
}
