namespace Concurrency.ConsoleApp;

public sealed class Example_9991 : IExample
{
    public async Task MainAsync()
    {
        using var cts = new CancellationTokenSource();

        var task = RunAsync(cts.Token);

        Console.ReadLine();
        await cts.CancelAsync()
            .ConfigureAwait(false);

        Console.WriteLine("Cancellation was requested. Waiting for the task to finish.");
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Task is finished.");
        }

        Console.ReadLine();
    }

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        // Every 5 seconds, spawn 2 Tasks, each of which will work for 4 seconds.
        while (true)
        {
            // Run forever until cancellation is requested.
            cancellationToken.ThrowIfCancellationRequested();

            // Wait for 5 seconds.
            await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken)
                .ConfigureAwait(false);

            // Create 2 tasks that will do this work on another background thread.
            _ = Task.Run(() => DoWorkAsync(cancellationToken), cancellationToken);
            _ = Task.Run(() => DoWorkAsync(cancellationToken), cancellationToken);
        }
    }

    public async Task DoWorkAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine($"Starting doing work from {Environment.CurrentManagedThreadId} thread.");

        // Wait for 2 seconds.
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken)
            .ConfigureAwait(false);

        Console.WriteLine($"Doing work from {Environment.CurrentManagedThreadId} thread.");

        // Wait another 2 seconds.
        await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken)
            .ConfigureAwait(false);

        Console.WriteLine($"Finished doing work from {Environment.CurrentManagedThreadId} thread.");
    }
}
