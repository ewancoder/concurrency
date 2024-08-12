namespace Concurrency.ConsoleApp;

public sealed class Example_992 : IExample
{
    public void Main()
    {
        DoThing("ivan");
    }

    private void DoThing(string value)
    {
        DoThing(value + value);
    }
}
