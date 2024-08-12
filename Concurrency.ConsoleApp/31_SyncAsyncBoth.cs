namespace Concurrency.ConsoleApp;

public sealed class Example_31 : IExample
{
    public async Task MainAsync()
    {
        var value = MyMethodAsync(isSync: true).GetAwaiter().GetResult();

        value = await MyMethodAsync(isSync: false);

        Console.ReadLine();
    }

    public async Task<string> MyMethodAsync(bool isSync)
    {
        if (isSync)
            Thread.Sleep(1000);
        else
            await Task.Delay(1000);

        return "Hello!";
    }
}
