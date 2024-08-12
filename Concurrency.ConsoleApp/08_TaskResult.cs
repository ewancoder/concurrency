namespace Concurrency.ConsoleApp;

public sealed class Example_8 : IExample
{
    public void Main()
    {
        var task = GetSomeTask();
        task.Wait();
        var result = task.Result;

        var task2 = Task.FromResult(3);

        var task3 = Task.FromException(new NotImplementedException());
        //task.Wait();

        //var task4 = Task.FromCanceled(default);

        var task5 = Task.CompletedTask;

        task3.Wait();
        //task3.GetAwaiter().GetResult();

        Console.ReadLine();
    }

    // Try/catch if needed.
    private Task<string> GetSomeTask()
    {
        //return "Hello";

        // throw new InvalidOperationException(); // Wrap this!
        return Task.FromResult("Hello");
    }
}
