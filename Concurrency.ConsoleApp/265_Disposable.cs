namespace Concurrency.ConsoleApp;

public sealed class Example_265 : IExample
{
    public void Main()
    {
        var task = DoSomethingAsync();
        task.Wait();

        var content = task.Result.Content.ReadAsStringAsync().Result;
        Console.WriteLine(content);

        Console.ReadLine();
    }

    // Refactor?
    public async Task<HttpResponseMessage> DoSomethingAsync()
    {
        // Scopeless even less visible.
        using (var client = new HttpClient())
        {
            return await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://google.com"));
        }
    }
}
