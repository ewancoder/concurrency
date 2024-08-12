using System.Threading.Tasks.Dataflow;

namespace Concurrency.ConsoleApp;

public sealed class Example_936 : IExample
{
    public void Main()
    {
        var actionBlock = new ActionBlock<string>(text =>
        {
            var doubledText = text + text;

            Console.WriteLine(doubledText);
        });

        var anotherActionBlock = new ActionBlock<string>(text =>
        {
            Console.WriteLine(text.Length);
        });

        // BufferBlock, BatchBlock, etc
        var broadcast = new BroadcastBlock<string>(text => $"cloned {text}");
        broadcast.LinkTo(anotherActionBlock);
        broadcast.LinkTo(actionBlock);

        broadcast.Post("Hello");
        Thread.Sleep(1000);
        broadcast.Post("World");
        broadcast.Complete();

        Console.ReadLine();
    }
}
