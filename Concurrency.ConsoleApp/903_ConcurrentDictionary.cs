using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class Example_903 : IExample
{
    public void Main()
    {
        var dictionary = new ConcurrentDictionary<string, Book>();

        for (var i = 0; i < 100; i++)
        {
            var year = i;
            Task.Run(() =>
            {
                dictionary.AddOrUpdate(
                    "key",
                    new Book("Title", "Author", year),
                    (key, existing) => new Book(existing.Title + "ha", existing.Author, existing.Year + year));
            });
        }

        Thread.Sleep(1000);
        dictionary.TryGetValue("key", out var book);

        Console.WriteLine(book.Title + book.Year);
        Console.ReadLine();

        //dictionary.TryAdd();
        //dictionary.TryUpdate();
        //dictionary.TryRemove();
        //dictionary.GetOrAdd("key", new Book());
    }
}
