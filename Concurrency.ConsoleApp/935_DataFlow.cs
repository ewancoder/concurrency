using System.Threading.Tasks.Dataflow;

namespace Concurrency.ConsoleApp;

public sealed class Example_935 : IExample
{
    public void Main()
    {
        var actionBlock = new ActionBlock<string>(text =>
        {
            var doubledText = text + text;

            Console.WriteLine(doubledText);
        });

        actionBlock.Post("Hello");
        actionBlock.Post("World");

        actionBlock.Complete();
        actionBlock.Post("Can't do this");

        Console.ReadLine();
    }
}
