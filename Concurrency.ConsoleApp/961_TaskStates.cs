namespace Concurrency.ConsoleApp;

public sealed class Example_961 : IExample
{
    public void Main()
    {
        var task = new Task(() => { });
        var status = task.Status;

        _ = task.IsCanceled;
        _ = task.IsCompleted; // If faulted or canceled, this property returns true.
        _ = task.IsFaulted;
        _ = task.IsCompletedSuccessfully;

        Console.WriteLine("Starting a task");
        //task = Task.Factory.StartNew(() =>
        task = Task.Run(() =>
        {
            Thread.Sleep(1000);

            _ = Task.Factory.StartNew(() => Thread.Sleep(5000), TaskCreationOptions.AttachedToParent);
            _ = Task.Factory.StartNew(() => Thread.Sleep(5000), TaskCreationOptions.AttachedToParent);
            _ = Task.Factory.StartNew(() => Thread.Sleep(5000), TaskCreationOptions.AttachedToParent);
        });
        task.Wait();
        Console.WriteLine($"Task executed");

        Console.ReadLine();
    }
}
