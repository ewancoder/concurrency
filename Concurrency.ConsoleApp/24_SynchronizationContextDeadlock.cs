namespace Concurrency.ConsoleApp;

public sealed class Example_24 : IExample
{
    public void Main()
    {
        SynchronizationContext.SetSynchronizationContext(
            new NaiveSingleThreadSynchronizationContext());

        new TaskFactory(TaskScheduler.FromCurrentSynchronizationContext())
            .StartNew(OnButtonClick);

        Console.ReadLine();
    }

    // Or OLD Asp .NET Framework endpoint.
    public void OnButtonClick()
    {
        IExample.Write("Inside OnButtonClick");

        var result = GetDataAsync().Result;

        IExample.Write("Got data from external source, updating the UI");
    }

    public async Task<string> GetDataAsync()
    {
        IExample.Write("Started external HTTP call");

        await Task.Delay(1000);

        IExample.Write("Finished external HTTP call, returning data");

        return "Ivan";
    }
}
