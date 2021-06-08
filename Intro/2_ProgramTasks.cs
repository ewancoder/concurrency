using System;
using System.Threading;
using System.Threading.Tasks;

namespace Intro
{
    public static class Program2
    {
        public static void Main()
        {
            PrintWithThread("Started main method.");

            Action<object> action = (state) =>
            {
                //Thread.Sleep(10);
                PrintWithThread("Inside our action.");

                //Thread.Sleep(10);
                PrintWithThread(state?.ToString());
            };

            Action simpleAction = () =>
            {
                //Thread.Sleep(10);
                PrintWithThread("Simple action first line.");

                //Thread.Sleep(10);
                PrintWithThread("Simple action second line.");
            };

            var task1 = new Task(action, "some state");
            var task2 = new Task(simpleAction);

            //task1.Start();
            //task2.Start();

            //Task.Run(simpleAction);
            //Task.Run(simpleAction);

            /*Task.Factory.StartNew(
                simpleAction,
                CancellationToken.None,
                TaskCreationOptions.DenyChildAttach,
                TaskScheduler.Default);*/
            /*Task.Factory.StartNew(
                action,
                "state",
                CancellationToken.None,
                TaskCreationOptions.DenyChildAttach,
                TaskScheduler.Default);*/

            PrintWithThread("Finished main method.");
            Console.ReadLine();
        }

        public static void PrintWithThread(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
