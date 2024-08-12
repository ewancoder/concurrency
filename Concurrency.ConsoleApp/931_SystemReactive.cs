using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Concurrency.ConsoleApp;

public sealed class Example_931 : IExample
{
    public void Main()
    {
        var behaviorSubject = new BehaviorSubject<Book>(new Book("Initial", "", 0));

        // IObservable exists in .NET SDK
        //var observable = new int[] { 1, 2, 3 }.ToObservable();
        //observable.Subscribe();

        behaviorSubject
            .Select(book => book.Title)
            .Where(title => title != "Initial")
            //.Skip(3)
            //.Throttle(TimeSpan.FromSeconds(0.5))
            //.DistinctUntilChanged()
            //.TakeWhile(title => title.Contains("2"))
            .Subscribe(title =>
            {
                Console.WriteLine(title);
            });

        _ = RunAsync(behaviorSubject);
        Console.ReadLine();
    }

    public async Task RunAsync(BehaviorSubject<Book> subject)
    {
        while (true)
        {
            await Task.Delay(1000);
            var title = Guid.NewGuid().ToString();

            subject.OnNext(new Book(title.ToString(), "", 0));
            subject.OnNext(new Book(title.ToString(), "", 0));
            subject.OnNext(new Book(title.ToString(), "", 0));
        }
    }
}
