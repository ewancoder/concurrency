using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class Example_901 : IExample
{
    public void Main()
    {
        var queue = new ConcurrentQueue<Book>();

        for (var i = 0; i < 100; i++)
        {
            var year = i;

            Task.Run(() =>
            {
                queue.Enqueue(new Book("Title", "Author", year));
            });
        }

        _ = Task.Run(async () =>
        {
            while (true)
            {
                //var isSuccess = queue.TryPeek(out var book);
                if (!queue.TryDequeue(out var book))
                {
                    await Task.Delay(1);
                    continue;
                }

                Console.WriteLine(book.Year);
            }
        });

        Console.ReadLine();
    }
}
