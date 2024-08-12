namespace Concurrency.ConsoleApp;

public sealed class Example_16 : IExample
{
    private readonly Task _task = Task.Run(() => Thread.Sleep(1000));
    //private readonly Task _task = Task.Run(() => Thread.Sleep(3000));

    public void Main()
    {
        IExample.Write("Started main thread. Gonna wait for something");

        DoSomethingAsync().Wait();

        IExample.Write("Finished waiting");

        Console.ReadLine();
    }

    public async Task DoSomethingAsync()
    {
        //await Task.CompletedTask;
        //await Task.Yield();

        IExample.Write("Started doing something");
        Thread.Sleep(2000);

        IExample.Write("Going to await long running operation");
        await LongRunningOperationAsync();
        IExample.Write("Awaited. Continuing");

        Thread.Sleep(2000);
        IExample.Write("Exiting DoSomethingAsync method");
    }

    private Task LongRunningOperationAsync()
    {
        return _task;
    }
}
