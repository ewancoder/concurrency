namespace Concurrency.ConsoleApp;

public sealed class Example_21 : IExample
{
    public void Main()
    {
        var task1 = ReturnTask1Async();
        var task2 = ReturnTask2Async();

        var allTask = Task.WhenAll(task1, task2);
        allTask.Wait();
        Console.WriteLine(task1.Result);
        Console.WriteLine(task2.Result);

        Console.ReadLine();
    }

    public Task<string> ReturnTask1Async()
    {
        var name = "Ivan";
        var lastName = "Zyranau";

        return Task.Delay(5000)
            .ContinueWith<string>(_ => $"{name} {lastName}");
    }

    public async Task<string> ReturnTask2Async()
    {
        var name = "Ivan";
        var lastName = "Zyranau";

        await Task.Delay(5000);

        return $"{name} {lastName}";
    }
}
