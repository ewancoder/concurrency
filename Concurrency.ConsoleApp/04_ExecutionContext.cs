namespace Concurrency.ConsoleApp;

public sealed class Example_4 : IExample
{
    private static readonly AsyncLocal<string> _asyncLocalName = new();
    private static string? _staticName;

    public void Main()
    {
        //ExecutionContext.SetData
        _staticName = "Ivan";
        _asyncLocalName.Value = "Ivan";

        //ExecutionContext.SuppressFlow();

        ThreadPool.QueueUserWorkItem(ChangeValues);
        ThreadPool.QueueUserWorkItem(DoSomething);

        Console.ReadLine();
    }

    private void DoSomething(object? state)
    {
        Thread.Sleep(2000);

        IExample.Write($"Static value: {_staticName}");
        IExample.Write($"AsyncLocal value: {_asyncLocalName.Value}");
    }

    private void ChangeValues(object? state)
    {
        _staticName = "Peter";
        _asyncLocalName.Value = "Peter";

        IExample.Write($"Changed AsyncLocal value to {_asyncLocalName.Value}");
    }
}
