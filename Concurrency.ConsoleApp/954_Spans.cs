namespace Concurrency.ConsoleApp;

public ref struct MyStruct
{
}

public sealed class Example_954 : IExample
{
    public void Main()
    {
        var array = new[]
        {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Fifth"
        };

        // Ref and Length.
        var span = array.AsSpan(); // ref struct
        var spanSubset = array.AsMemory(); // struct

        var anotherSpan = span.Slice(2, 2);

        var readOnlySpan = new ReadOnlySpan<string>(array);
        readOnlySpan.Slice(2, 2);

        Console.ReadLine();
    }

    //public async void DoSomething(Span<string> span)
    public async void DoSomething(Memory<string> memory)
    {
        //var span = new Span<string>(new string[5]);
    }
}
