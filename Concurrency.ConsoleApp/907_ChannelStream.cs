using System.Threading.Channels;

namespace Concurrency.ConsoleApp;

public sealed class Example_907 : IExample
{
    public void Main()
    {
        // .NET Core 3.
        var channel = Channel.CreateBounded<Book>(5);
        /*var options = new BoundedChannelOptions(5)
        {
            SingleReader = false,
            SingleWriter = false,
            Capacity = 5,
            FullMode = BoundedChannelFullMode.Wait
        };*/

        Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(1000);

                //channel.Writer.TryWrite
                await channel.Writer.WriteAsync(new Book("Title", "Author", 2000)/*, cancellationToken*/);

                if (false /* need to stop */)
                    channel.Writer.Complete();
            }
        });

        Task.Run(async () =>
        {
            await foreach (var item in channel.Reader.ReadAllAsync(/*, cancellationToken*/))
            {
                Console.WriteLine(item.Title);
            }
        });

        Console.ReadLine();
    }
}
