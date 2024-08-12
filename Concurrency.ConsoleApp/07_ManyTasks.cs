namespace Concurrency.ConsoleApp;

public sealed class Example_7 : IExample
{
    public void Main()
    {
        List<Task<string>> tasks = [];
        for (var i = 1; i <= 10; i++)
        {
            var task = Task.Run(DoSomething);
            tasks.Add(task);
        }

        //Task.WaitAny(tasks);
        Task.WaitAll([.. tasks]);
        //Thread.Sleep(5000);

        Console.WriteLine(tasks[4].Status);
        Console.WriteLine(tasks[4].Result);
        //tasks[4].Exception;

        Console.ReadLine();
    }

    private string DoSomething()
    {
        //throw new InvalidOperationException();
        Thread.Sleep(10000);

        IExample.Write("Done");
        return Guid.NewGuid().ToString();
    }
}
