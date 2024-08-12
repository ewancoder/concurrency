namespace Concurrency.ConsoleApp;

public sealed class Example_28 : IExample
{
    public void Main()
    {
        _ = RunAsync();

        var vt = DoSomethingElse2Async();
        vt.AsTask().Wait();

        Console.ReadLine();
    }

    public async Task RunAsync()
    {
        await DoSomethingAsync();
    }

    public async ValueTask DoSomethingAsync()
    {
        IExample.Write("Started DoSomethingAsync");

        await Task.Delay(TimeSpan.FromSeconds(2));

        IExample.Write("In the middle of DoSomethingAsync");

        var response = await DoSomethingElseAsync();

        IExample.Write($"Exiting DoSomethingAsync, got {response}");
    }

    private async ValueTask<string> DoSomethingElseAsync()
    {
        if (DateTime.Now.Second % 2 == 0)
        {
            await Task.Delay(1000);

            return "Hello";
        }

        return "Hello";
    }

    // More examples

    private ValueTask<string> DoSomethingElse2Async()
    {
        if (DateTime.Now.Second % 2 == 0)
        {
            var task = Task.Delay(1000).ContinueWith(_ => "Hello");

            return new ValueTask<string>(task);
        }

        return new ValueTask<string>("Hello");
    }

    private string _cachedValue;
    private async ValueTask<string> GetCachedResultAsync()
    {
        if (true /* cache invalidation condition */)
        {
            var response = await new HttpClient().GetAsync("http://smth");
            var content = await response.Content.ReadAsStringAsync();

            _cachedValue = content;
        }

        return _cachedValue;
    }
}
