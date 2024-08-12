namespace Concurrency.ConsoleApp;

public sealed class Example_5 : IExample
{
    public void Main()
    {
        // Never do this!
        //var task = new Task(DoSomething);
        //task.Start();

        var task1 = Task.Run(DoSomething);
        var task2 = Task.Run(DoSomething);

        //var task3 = new TaskFactory().StartNew(DoSomething);

        Console.WriteLine(task1.Status); // WaitingToRun.
        Console.WriteLine(task1.IsCompleted);

        Thread.Sleep(1000);
        Console.WriteLine(task1.Status); // Running.

        task1.Wait(); // Shouldn't generally call this.

        Console.ReadLine();
    }

    private void DoSomething()
    {
        //throw new InvalidOperationException();
        Thread.Sleep(TimeSpan.FromHours(1));
    }
}
