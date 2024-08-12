namespace Concurrency.ConsoleApp;

public sealed class Example_235 : IExample
{
    public void Main()
    {
        var action = () => { /* Your code that needs to run on background thread */ };
        var completion = () => { /* Your code that needs to run on UI thread */ };

        var sc = SynchronizationContext.Current;
        ThreadPool.QueueUserWorkItem(_ =>
        {
            try
            {
                action();
            }
            finally
            {
                sc.Post(_ => completion(), null);
            }
        });

        Console.ReadLine();
    }

    // Or OLD Asp .NET Framework endpoint.
    public void OnButtonClick()
    {
        var sc = SynchronizationContext.Current;

        new HttpClient().GetAsync("http://something").ContinueWith(t =>
        {
            sc.Post(_ =>
            {
                // Update button text here, or UI or smth.
            }, null);
        });
    }

    public async void OnButtonClick2()
    {
        await new HttpClient().GetAsync("http://something");

        // Update button text here, or UI or smth.
    }
}
