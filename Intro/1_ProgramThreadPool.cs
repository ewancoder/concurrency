using System;
using System.Threading;
using System.Threading.Tasks;

namespace Intro
{
    public static class Program1
    {
        public static void Main1()
        {
            PrintWithThread("Started main method.");

            WaitCallback action = (state) =>
            {
                //Thread.Sleep(10);
                PrintWithThread("Inside our action.");

                //Thread.Sleep(10);
                PrintWithThread(state?.ToString());
            };

            ThreadPool.QueueUserWorkItem(action);
            //ThreadPool.QueueUserWorkItem(action, "some state");

            PrintWithThread("Finished main method.");
            Console.ReadLine();
        }

        public static void PrintWithThread(string message)
        {
            Console.WriteLine($"{message} [{Thread.CurrentThread.ManagedThreadId}]");
        }
    }
}
