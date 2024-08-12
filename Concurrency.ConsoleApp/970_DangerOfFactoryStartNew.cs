namespace Concurrency.ConsoleApp;

public sealed class Example_970 : IExample
{
    public async Task MainAsync()
    {
        var task = Task.Factory.StartNew(async () =>
        {
            await Task.Delay(10000);
            Console.WriteLine("Finished background task");
        });

        await task;
        Console.WriteLine("Finished task");
    }
}
