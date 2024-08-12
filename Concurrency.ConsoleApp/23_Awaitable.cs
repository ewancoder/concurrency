using System.Runtime.CompilerServices;

namespace Concurrency.ConsoleApp;

public sealed class Example_23 : IExample
{
    public async void Main()
    {
        var task = Task.Run(() => { });
        await task;
        await task;

        ValueTask vt = default;
        await vt;

        MyClass myclass = new();
        await myclass;

        Console.ReadLine();
    }

    public sealed class MyClass
    {
        public MyAwaiter GetAwaiter()
        {
            return null!;
        }
    }

    public sealed class MyAwaiter : INotifyCompletion
    {
        public bool IsCompleted { get; }

        public void OnCompleted(Action continuation)
        {
            throw new NotImplementedException();
        }

        public object GetResult()
        {
            return null!;
        }
    }
}
