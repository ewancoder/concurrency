namespace Concurrency.ConsoleApp;

public sealed class BadClass1
{
    // Bad.
    public Task DoSomethingAsync2()
    {
        return Task.Run(DoSomethingSync);
    }

    // Even worse.
    public async Task DoSomethingAsync()
    {
        DoSomethingSync();
    }

    private void DoSomethingSync()
    {
        Thread.Sleep(1000);
    }
}

public sealed class BadClass2
{
    // Horrible.
    public void DoSomethingSync()
    {
        DoSomethingAsync().GetAwaiter().GetResult();
    }

    private async Task DoSomethingAsync()
    {
        await Task.Delay(1000);
    }
}

public sealed class BigNumberCalculator
{
    // Bad.
    public Task CalculateSomething()
    {
        return Task.Run(() =>
        {
            long i = 0;
            while (true)
            {
                i++;

                if (i > 100_000_000_000)
                    return;
            }
        });
    }

    // The caller of this method MIGHT use Task.Run if they want to.
    public void CorrectImplementation()
    {
        long i = 0;
        while (true)
        {
            i++;

            if (i > 100_000_000_000)
                return;
        }
    }
}
