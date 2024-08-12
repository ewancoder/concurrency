namespace Concurrency.ConsoleApp;

public sealed class Example_951 : IExample
{
    public async Task MainAsync()
    {
        var task = DoSomething();

        try
        {
            // .NET 6.
            await task.WaitAsync(TimeSpan.FromSeconds(5));
        }
        catch (TimeoutException)
        {
            Console.WriteLine("Timeout!");
        }

        Console.ReadLine();
    }

    public async Task DoSomething()
    {
        await Task.Delay(10000);
    }
}
