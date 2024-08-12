namespace Concurrency.ConsoleApp;

public sealed class Example_964 : IExample
{
    public void Main()
    {
        var task = DoSomethingAsync()
            .ContinueWith(_ => DoSomethingAsync().Wait())
            .ContinueWith(_ => DoSomethingAsync().ContinueWith(_ => DoSomethingAsync().Wait()).Wait());

        try
        {
            task.Wait();
        }
        catch (AggregateException exception)
        {
            var flattenedException = exception.Flatten();
        }

        task.Exception.Handle(exception => true);

        var ex = task.Exception;

        TaskScheduler.UnobservedTaskException += (sender, args) =>
        {
            var exception = args.Exception;
            Console.WriteLine("Unobserved exception happened");
        };

        GC.Collect();
        Console.ReadLine();
    }

    public async Task DoSomethingAsync()
    {
        throw new InvalidOperationException();
    }
}
