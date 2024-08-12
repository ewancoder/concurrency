namespace Concurrency.ConsoleApp;

public sealed class Example_6 : IExample
{
    public void Main()
    {
        Task<string> task1 = Task.Run(DoSomething);
        var task2 = Task.Run(DoSomething);

        var result = task1.Result;
        // task1.Wait();
        // task1.GetAwaiter().GetResult();

        IExample.Write(result);
        Console.ReadLine();
    }

    private string DoSomething()
    {
        Thread.Sleep(1000);

        IExample.Write("Slept for 1 second, returning value");
        return "Hello";
    }
}
