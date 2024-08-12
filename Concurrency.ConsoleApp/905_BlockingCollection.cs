using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class Example_905 : IExample
{
    public void Main()
    {
        var bc = new BlockingCollection<Book>(5);

        Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(1000);
                bc.Add(new Book("Title", "Author", 2000));
                //bc.TryAdd();
            }
        });

        Task.Run(() =>
        {
            while (true)
            {
                Thread.Sleep(10);
                var book = bc.Take();
                Console.WriteLine(book.Title);
                //bc.TryTake();
            }
        });

        Console.ReadLine();
    }
}
