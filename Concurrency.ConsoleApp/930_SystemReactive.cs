using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Concurrency.ConsoleApp;

public sealed class Example_930 : IExample
{
    public void Main()
    {
        var behaviorSubject = new BehaviorSubject<Book>(new Book("Initial", "", 0));

        behaviorSubject
            .Subscribe(book =>
            {
                Console.WriteLine(book.Title);
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

            subject.OnNext(new Book(title, "", 0));
            subject.OnNext(new Book(title, "", 0));
            subject.OnNext(new Book(title, "", 0));
        }
    }
}
