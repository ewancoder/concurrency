using System.Collections.Immutable;

namespace Concurrency.ConsoleApp;

public sealed class Example_910 : IExample
{
    public void Main()
    {
        var immutableQueue = ImmutableQueue<Book>.Empty;

        immutableQueue = immutableQueue.Enqueue(new Book("Title", "Author", 2000));
        immutableQueue = immutableQueue.Enqueue(new Book("Title", "Author", 2001));

        immutableQueue = immutableQueue.Dequeue(out var book);

        // These are not all of them.
        ImmutableArray.Create<Book>();
        ImmutableDictionary.Create<string, Book>();
        ImmutableHashSet.Create<Book>();
        ImmutableList.Create<Book>();
        ImmutableQueue.Create<Book>();

        var list = new List<Book>();
        var immutableSet = list.ToImmutableHashSet();
    }
}
