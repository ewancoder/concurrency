using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;

namespace Concurrency.ConsoleApp;

public sealed class Example_950 : IExample
{
    public async Task MainAsync()
    {
        var value = await GetStringAsync();

        Console.WriteLine(value);
        Console.ReadLine();
    }

    private ValueTask<string> GetStringAsync()
    {
        return new(new GetStringValueTaskSource(), 10);
    }

    /*[AsyncMethodBuilder(typeof(PoolingAsyncValueTaskMethodBuilder<string>))]
    private async ValueTask<string> AutomaticMethodAsync()
    {
        await Task.Delay(1000);

        return "Hello, World!";
    }*/
}

public sealed class GetStringValueTaskSource : IValueTaskSource<string>
{
    public string GetResult(short token)
    {
        throw new NotImplementedException();
    }

    public ValueTaskSourceStatus GetStatus(short token)
    {
        throw new NotImplementedException();
    }

    public void OnCompleted(
        Action<object?> continuation,
        object? state,
        short token,
        ValueTaskSourceOnCompletedFlags flags)
    {
        throw new NotImplementedException();
    }
}
