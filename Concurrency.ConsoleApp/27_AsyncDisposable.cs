using Microsoft.Extensions.DependencyInjection;

namespace Concurrency.ConsoleApp;

public sealed class Example_27 : IExample
{
    public async Task MainAsync()
    {
        // First option. No ConfigureAwait
        await using (var instance = new MyDisposableObject())
        {
            // Code.
        }

        // Second option.
        {
            var instance = new MyDisposableObject();
            await using (instance.ConfigureAwait(false))
            {
                // Code.
            }

            // Code can still access instance2 but will throw ObjectDisposedException.
        }

        // Third option. No await using.
        {
            var instance = new MyDisposableObject();
            try
            {
                // Code.
            }
            finally
            {
                await instance.DisposeAsync()
                    .ConfigureAwait(false);
            }

            // Code can still access instance2 (if no exceptions) but will throw ObjectDisposedException.
        }

        // Fourth option. Scopeless.
        {
            var instance = new MyDisposableObject();
            await using var _ = instance.ConfigureAwait(false);

            // Code.
        }

        Console.ReadLine();
    }
}

public sealed class MyDisposableObject : IAsyncDisposable
{
    public async ValueTask DisposeAsync()
    {
        await Task.Delay(1000);

        // Disposed.
    }
}

public static class Test
{
    public static void Run(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var myObj = serviceProvider.GetRequiredService<MyDisposableObject>();
        }
    }
}
