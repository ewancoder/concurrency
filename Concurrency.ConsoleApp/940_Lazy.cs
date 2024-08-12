namespace Concurrency.ConsoleApp;

public sealed class Example_940 : IExample
{
    private Lazy<Book> _lazy;

    public void Main()
    {
        _lazy = new Lazy<Book>(CreateNewBook);
        //_ = _lazy.Value;

        Parallel.For(1, 11, iteration => Console.WriteLine(_lazy.Value.Title));

        Console.ReadLine();

        Parallel.For(1, 11, iteration => Console.WriteLine(_lazy.Value.Title));

        Console.ReadLine();
    }

    private int year = 2000;
    private Book CreateNewBook()
    {
        Console.WriteLine("Creating a book");

        return new Book("Title", "Author", year++);
    }
}
