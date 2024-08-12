var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHostedService<MyBackgroundService>();

var app = builder.Build();
app.MapGet("/now", () => DateTime.UtcNow);

await app.RunAsync()
    .ConfigureAwait(false);

public sealed class MyBackgroundService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        // We need to do something blocking here.
        Thread.Sleep(TimeSpan.FromHours(1));
        //await Task.Delay(TimeSpan.FromHours(1));
    }
}
