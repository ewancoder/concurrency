namespace Concurrency.ConsoleApp;

public sealed class Example_953 : IExample
{
    bool set = false;
    int value = 0;

    public void Main()
    {
        Task.Run(async () =>
        {
            while (true)
            {
                if (set)
                {
                    Console.WriteLine(value);
                    break;
                }
            }
        });

        Console.ReadLine();
        Task.Run(async () =>
        {
            value = 100;
            //Thread.MemoryBarrier();
            set = true;
        });

        Console.ReadLine();
    }
}
