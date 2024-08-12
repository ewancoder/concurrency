namespace Concurrency.ConsoleApp;

public sealed class Example_991 : IExample
{
    public void Main()
    {
        while (true)
        {
            Console.ReadLine();

            Task.Run(DoWorkAsync);
        }
    }

    private async Task DoWorkAsync()
    {
        IExample.Write("Line one");

        await Task.Delay(1000);

        IExample.Write("Line two");

        await Task.Delay(1000);

        IExample.Write("Line three");

        await Task.Delay(1000);

        IExample.Write("Done");
    }
}
