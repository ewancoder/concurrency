namespace Concurrency.ConsoleApp;

public sealed class Example_1 : IExample
{
    public void Main()
    {
        Thread.Sleep(TimeSpan.FromHours(1));

        Console.ReadLine();
    }
}
