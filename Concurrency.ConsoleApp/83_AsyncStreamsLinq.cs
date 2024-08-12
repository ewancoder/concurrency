namespace Concurrency.ConsoleApp;

public sealed class Example_83 : IExample
{
    public async Task MainAsync()
    {
        var generator = GetBooksAsync();

        var filteredGenerator = generator
            .Take(10)
            .Where(x => x.Author.Length > 3)
            .Select(x => x.Year);
        //.OrderBy(x => x);

        try
        {
            await foreach (var year in filteredGenerator)
            {
                Console.WriteLine(year);
            }
        }
        catch
        {
        }

        Console.ReadLine();
    }

    async IAsyncEnumerable<Book> GetBooksAsync()
    {
        var i = 0;
        while (true)
        {
            if (i == 0)
            {
                await Task.Delay(1000); // Get next page.
            }

            i++;
            if (i > 3) i = 0;

            //if (i == 3) throw new InvalidOperationException("Hello");

            yield return new Book(Guid.NewGuid().ToString(), "Author", 2000);
        }
    }
}
