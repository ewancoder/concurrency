namespace Concurrency.ConsoleApp;

public sealed record Book(string Title, string Author, int Year);

public sealed class BooksGenerator
{
    public static IEnumerable<Book> Generate()
    {
        var year = 1900;
        while (true)
        {
            year++;
            yield return new($"Title {year}", $"Author {year}", year);
        }
    }

    public static string HashTitle(string title)
    {
        Thread.Sleep(2000);
        Console.WriteLine("hashed");

        return $"Hashed {title}";
    }

    // Return ValueTask
    public static async Task<string> HashTitleAsync(string title)
    {
       await Task.Delay(2000);

        return $"Hashed {title}";
    }
}

public sealed class Example_73 : IExample
{
    public void Main()
    {
        var books = BooksGenerator.Generate();

        var filteredBooks = books
            .Take(16)
            .Select(book => book with { Year = book.Year * 2 })
            .AsParallel()
            //.WithDegreeOfParallelism(6)
            //.AsOrdered()
            .Select(book => book with { Title = BooksGenerator.HashTitle(book.Title) })
            //.AsUnordered()
            //.AsSequential()
            .Where(book => book.Title.Contains('3'))
            .ToList();

        Console.ReadLine();
    }
}
