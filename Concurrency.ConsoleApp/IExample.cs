using System.Diagnostics;
using System.Reflection;

namespace Concurrency.ConsoleApp;

internal interface IExample
{
    public virtual void Main() { }
    public virtual Task MainAsync() => Task.CompletedTask;
    public static TaskScheduler? Scheduler { get; }

    [DebuggerHidden]
    public static void Run(string? id)
    {
        var scheduler = Scheduler;
        var instance = GetById(id);
        if (instance == null)
            return;

        instance.Main();
        instance.MainAsync().Wait();
        //Console.ReadLine(); // Uncomment this later.
    }

    protected static IExample? GetById(string? id)
    {
        var type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetInterface(nameof(IExample)) != null)
            .SingleOrDefault(x => x.Name.Split('_').Last() == id);

        if (type == null)
            return null;

        return (IExample)Activator.CreateInstance(type)!;
    }

    [DebuggerHidden]
    public static void Write(string message)
    {
        var row = string.Format(
            "{0,3} {1,20} {2,1} | {3,5}",
            Environment.CurrentManagedThreadId,
            Thread.CurrentThread.Name,
            SynchronizationContext.Current,
            message);

        Console.WriteLine(row);
    }
}
