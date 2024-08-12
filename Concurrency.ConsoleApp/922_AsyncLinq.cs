namespace Concurrency.ConsoleApp;

public sealed class Example_922 : IExample
{
    async Task MainAsync()
    {
        var generator = GetBooksAsync();

        var filteredGenerator = generator
            .Take(10)
            .Where(x => x.Author.Length > 3)
            .WhereAwait(async x =>
            {
                await Task.Delay(400);
                return x.Year > 200;
            })
            //.GroupByAwait
            .SelectAwait(async x => await BooksGenerator.HashTitleAsync(x.Title));

        /*await foreach (var year in filteredGenerator)
        {
            Console.WriteLine(year);
        }*/

        //var sum = filteredGenerator.MaxAsync
        var sumOfCharacters = await filteredGenerator.SumAsync(x => x.Length);

        var sumOfCharactersAsync = await filteredGenerator.SumAwaitAsync(async x =>
        {
            await Task.Delay(1000);
            return x.Length;
        });

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

            yield return new Book(Guid.NewGuid().ToString(), "Author", 2000);
        }
    }
}
