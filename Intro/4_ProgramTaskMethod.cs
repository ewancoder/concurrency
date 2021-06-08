using System;
using System.Threading;
using System.Threading.Tasks;

namespace Intro
{
    public static class Program4
    {
        public static void Main4()
        {
            PrintWithThread("Started main method.");

            var task = SomeMethodAsync();
            task.Wait();

            var task2 = AnotherMethodAsync();
            task2.Wait();

            PrintWithThread("Finished main method.");
            Console.ReadLine();
        }

        public static Task SomeMethodAsync()
        {
            PrintWithThread("Inside some method");

            var task = Task.Run(() =>
            {
                Thread.Sleep(500);
                PrintWithThread("Running on background thread");
            });

            PrintWithThread("Returning from some method");

            return task;
        }

        public static Task AnotherMethodAsync()
        {
            PrintWithThread("Inside another method");

            Thread.Sleep(500);

            PrintWithThread("Returning from some method");

            return Task.CompletedTask;
        }

        public static void PrintWithThread(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
