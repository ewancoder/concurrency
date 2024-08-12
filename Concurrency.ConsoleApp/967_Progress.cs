namespace Concurrency.ConsoleApp;

public sealed class Example_967 : IExample
{
    public void Main()
    {
        Progress<int> progress = new Progress<int>();

        progress.ProgressChanged += (sender, e) => Console.WriteLine($"Received {e}");

        Task.Run(() =>
        {
            var i = 0;
            while (true)
            {
                i++;
                ((IProgress<int>)progress).Report(i);
            }
        });

        Console.ReadLine();
    }
}
