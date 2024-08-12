namespace Concurrency.ConsoleApp;

public sealed class Example_962 : IExample
{
    public void Main()
    {
        var defaultScheduler = TaskScheduler.Default;
        //var contextScheduler = TaskScheduler.FromCurrentSynchronizationContext();

        var pair = new ConcurrentExclusiveSchedulerPair(defaultScheduler /* contextScheduler */, 3);
        var exclusiveScheduler = pair.ExclusiveScheduler;
        var concurrentScheduler = pair.ConcurrentScheduler;

        Task.Factory.StartNew(BlockThreadAsync, default, TaskCreationOptions.None, exclusiveScheduler);
        Task.Factory.StartNew(BlockThreadAsync, default, TaskCreationOptions.None, exclusiveScheduler);
        Task.Factory.StartNew(BlockThreadAsync, default, TaskCreationOptions.None, exclusiveScheduler);

        Console.ReadLine();

        TaskCreationOptions options;

        /*var factory = new TaskFactory(default, TaskCreationOptions.AttachedToParent, TaskContinuationOptions.HideScheduler, exclusiveScheduler);
        factory.StartNew(BlockThreadAsync);
        factory.StartNew(BlockThreadAsync);*/

        // Task.Run equivalent.
        /*Task.Factory.StartNew(
            action: BlockThreadAsync,
            cancellationToken: default,
            creationOptions: TaskCreationOptions.DenyChildAttach,
            scheduler: TaskScheduler.Default);*/
    }

    private void BlockThreadAsync()
    {
        Thread.Sleep(1000);
        Console.WriteLine("Finishing block thread method");
    }
}
