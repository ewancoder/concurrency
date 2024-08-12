using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class Example_902 : IExample
{
    public void Main()
    {
        var stack = new ConcurrentStack<Book>();

        for (var i = 0; i < 100; i++)
        {
            var year = i;

            Task.Run(() => stack.Push(new Book("Title", "Author", year)));
        }

        _ = Task.Run(async () =>
        {
            while (true)
            {
                //var isSuccess = stack.TryPeek(out var book);
                //stack.PushRange
                //stack.TryPopRange
                if (!stack.TryPop(out var book))
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
