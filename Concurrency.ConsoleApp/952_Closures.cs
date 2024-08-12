namespace Concurrency.ConsoleApp;

public sealed class Example_952 : IExample
{
    public void Main()
    {
        var book = new Book("Title", "Author", 2000);

        ThreadPool.QueueUserWorkItem(state =>
        {
            Console.WriteLine(book);
        });

        ThreadPool.QueueUserWorkItem(state =>
        {
            Console.WriteLine(state);
        }, book);

        // And Tasks

        Task.Run(() =>
        {
            Console.WriteLine(book);
        });

        Task.Factory.StartNew(state =>
        {
            Console.WriteLine(state);
        }, book);

        Console.ReadLine();
    }
}
