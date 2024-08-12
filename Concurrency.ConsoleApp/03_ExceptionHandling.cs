namespace Concurrency.ConsoleApp;

public sealed class Example_3 : IExample
{
    public void Main()
    {
        ThreadPool.QueueUserWorkItem(DoSomething);

        Console.ReadLine();
    }

    private void DoSomething(object? state)
    {
        Thread.Sleep(5000);
        throw new InvalidOperationException();
    }
}
