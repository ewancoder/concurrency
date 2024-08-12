namespace Concurrency.ConsoleApp;

public sealed class Example_923 : IExample
{
    public async Task MainAsync()
    {
        // Not an ASYNC enumerable.
        IEnumerable<Book> books = BooksGenerator.Generate();

        var filteredBooks = books
            .Take(16)
            .AsParallel()
            .Select(book => book with { Title = BooksGenerator.HashTitle(book.Title) });

        foreach (var book in filteredBooks)
        {
            Console.WriteLine(book.Title);
        }

        Console.ReadLine();
    }

    async Task RunAsync2()
    {
        IEnumerable<Book> books = BooksGenerator.Generate();

        var asyncBooks = books
            .ToAsyncEnumerable()
            .Take(16)
            //.AsParallel() // No such method
            .SelectAwait(async book => book with { Title = await BooksGenerator.HashTitleAsync(book.Title) });

        await foreach (var book in asyncBooks)
        {
            Console.WriteLine(book.Title);
        }
    }

    async Task RunAsync3()
    {
        IEnumerable<Book> books = BooksGenerator.Generate();

        var asyncBooks = books
            .Take(16)
            //.AsParallel()
            .Select(book => Task.Run(async () =>
            {
                return book with { Title = await BooksGenerator.HashTitleAsync(book.Title) };
            }))
            .ToAsyncEnumerable()
            .SelectAwait(async task => await task);

        await foreach (var book in asyncBooks)
        {
            Console.WriteLine(book.Title);
        }
    }
}
