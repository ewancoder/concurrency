namespace Concurrency.ConsoleApp;

public sealed class Example_72 : IExample
{
    public void Main()
    {
        var options = new ParallelOptions
        {
            MaxDegreeOfParallelism = 3
        };

        Parallel.For(fromInclusive: 1, toExclusive: 101, options, (index, state) =>
        {
            if (state.ShouldExitCurrentIteration)
                return;

            Thread.Sleep(1000);

            Console.WriteLine(index);

            if (index > 50)
                state.Stop();

            /*if (index > 25 && state.LowestBreakIteration == null)
                state.Break();

            var anyOtherIterationThrewException = state.IsExceptional;*/
        });

        Console.ReadLine();
    }
}
