namespace Concurrency.ConsoleApp;

public sealed class Example_963 : IExample
{
    public void Main()
    {
        var task = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("First part");
        }).ContinueWith(previousTask =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("Second part");
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        Console.ReadLine();
    }
}
