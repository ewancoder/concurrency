using System;
using System.Threading;
using System.Threading.Tasks;

namespace Intro
{
    public static class Program3
    {
        public static void Main3()
        {
            PrintWithThread("Started main method.");

            Action action = () =>
            {
                PrintWithThread("Inside our action.");

                //throw new InvalidOperationException();
            };

            var task = new Task(action);
            Console.WriteLine(task.Status); // Created.

            task.Start();
            Console.WriteLine(task.Status); // WaitingToRun.

            //task.Start(); // Exception.

            task.Wait();
            Console.WriteLine(task.Status); // RanToCompletion.

            Console.WriteLine(task.IsCompleted);
            Console.WriteLine(task.IsCanceled);
            Console.WriteLine(task.IsFaulted);
            Console.WriteLine(task.IsCompletedSuccessfully);

            PrintWithThread("Finished main method.");
            Console.ReadLine();
        }

        public static void PrintWithThread(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
