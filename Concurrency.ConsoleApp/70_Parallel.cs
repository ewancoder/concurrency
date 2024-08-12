namespace Concurrency.ConsoleApp;

public sealed class Example_70 : IExample
{
    public void Main()
    {
        Parallel.For(fromInclusive: 1, toExclusive: 11, index =>
        {
            Thread.Sleep(5000);

            Console.WriteLine(index);
        });

        Console.ReadLine();
    }
}
