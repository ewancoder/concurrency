using System.Threading.Channels;

namespace Concurrency.ConsoleApp;

public sealed class Example_906 : IExample
{
    public void Main()
    {
        var channel = Channel.CreateBounded<Book>(5);
        //var channel = Channel.CreateUnbounded<Book>();

        Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(1000);

                //channel.Writer.TryWrite
                //channel.Writer.Complete()
                await channel.Writer.WriteAsync(new Book("Title", "Author", 2000)/*, cancellationToken*/);
            }
        });

        Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(10);

                //channel.Reader.TryRead
                //channel.Reader.TryPeek
                //channel.Reader.WaitToReadAsync
                //channel.Reader.Completion (Task)
                var book = await channel.Reader.ReadAsync(/*, cancellationToken*/);

                Console.WriteLine(book.Title);
            }
        });

        Console.ReadLine();
    }
}
