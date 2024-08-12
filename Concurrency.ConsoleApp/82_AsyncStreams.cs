using System.Runtime.CompilerServices;

namespace Concurrency.ConsoleApp;

public sealed class Example_82 : IExample
{
    public void Main()
    {
        using var cts = new CancellationTokenSource();

        _ = RunAsync(cts.Token);
        Console.ReadLine();

        cts.Cancel();
        Console.ReadLine();
    }

    async Task RunAsync(CancellationToken cancellationToken)
    {
        var asyncEnumerable = GetBooksAsync(default);

        await foreach (var book in asyncEnumerable.WithCancellation(cancellationToken).ConfigureAwait(false))
        {
            Console.WriteLine(book.Title);
        }
    }

    async IAsyncEnumerable<Book> GetBooksAsync([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var i = 0;
        while (true)
        {
            if (i == 0)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.Delay(1000); // Get next page.
            }

            i++;
            if (i >= 3) i = 0;

            yield return new Book(Guid.NewGuid().ToString(), "Author", 2000);
        }
    }
}
