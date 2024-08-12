namespace Concurrency.ConsoleApp;

public sealed class Example_2 : IExample
{
    public void Main()
    {
        IExample.Write("Main method started.");

        ThreadPool.QueueUserWorkItem(DoSomething);
        ThreadPool.QueueUserWorkItem(DoSomething);

        IExample.Write("Main method finished.");

        Console.ReadLine();
    }

    private void DoSomething(object? state)
    {
        IExample.Write("Inside DoSomething");

        Thread.Sleep(TimeSpan.FromHours(1));
    }

    private void DoSomethingElse(object? state)
    {
        IExample.Write("Inside DoSomethingElse");

        Thread.Sleep(1000);
        IExample.Write(Guid.NewGuid().ToString());
    }
}
