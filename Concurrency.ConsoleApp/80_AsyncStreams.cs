namespace Concurrency.ConsoleApp;

public sealed class Example_80 : IExample
{
    public async Task MainAsync()
    {
        foreach (var book in GetBooks().Take(10))
        {
            //Console.WriteLine(book.Title);
        }

        foreach (var book in (await GetBooksEnumerableAsync()).Take(10))
        {
            //Console.WriteLine(book.Title);
        }

        // ConfigureAwait
        await foreach (var book in GetBooksAsync().Take(10))
        {
            Console.WriteLine(book.Title);
        }

        Console.ReadLine();
    }

    IEnumerable<Book> GetBooks()
    {
        while (true)
        {
            // How to await here?
            yield return new Book(Guid.NewGuid().ToString(), "Author", 2000);
        }
    }

    async Task<IEnumerable<Book>> GetBooksEnumerableAsync()
    {
        await Task.Delay(1000);

        return GetBooks().Take(100);
    }

    async IAsyncEnumerable<Book> GetBooksAsync()
    {
        var i = 0;
        while (true)
        {
            if (i == 0)
                await Task.Delay(1000); // Get next page.

            i++;
            if (i >= 3) i = 0;

            yield return new Book(Guid.NewGuid().ToString(), "Author", 2000);
        }
    }
}
