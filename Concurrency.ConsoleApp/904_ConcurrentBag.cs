using System.Collections.Concurrent;

namespace Concurrency.ConsoleApp;

public sealed class Example_904 : IExample
{
    public void Main()
    {
        var bag = new ConcurrentBag<Book>();

        for (var i = 0; i < 100; i++)
        {
            var year = i;
            Task.Run(() =>
            {
                bag.Add(new Book("Title", "Author", 2000 + year));
            });
        }

        //bag.TryTake();
        //bag.TryPeek();
    }
}
