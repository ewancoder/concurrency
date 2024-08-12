namespace Concurrency.ConsoleApp;

public class MyAsyncClass
{
    public MyAsyncClass()
    {
        InitializeAsync().Wait();
        //_ = InitializeAsync();

        Console.ReadLine();
    }

    private async Task InitializeAsync()
    {
        await Task.Delay(1000);
    }
}

public class BetterAsyncClass
{
    // PRIVATE constructor.
    private BetterAsyncClass(object state)
    {
        _ = state; // Set all needed variables here.
    }

    public async static Task<BetterAsyncClass> CreateAsync()
    {
        await Task.Delay(1000);

        var state = new object();
        return new BetterAsyncClass(state);
    }
}
