namespace Concurrency.ConsoleApp;

public sealed class Example_966 : IExample
{
    public void Main()
    {
        Parallel.For(1, 11,
            () => { return "initialized value"; },
            (index, state, initializedValue) => { Console.WriteLine(initializedValue); return initializedValue + 2; },
            finalValue => { Console.WriteLine(finalValue); });

        Console.ReadLine();
    }
}
