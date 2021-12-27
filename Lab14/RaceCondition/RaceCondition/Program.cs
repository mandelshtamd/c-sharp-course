using System;
using System.Threading;

namespace RaceCondition
{
    class Program
    {
        private static int count = 0;

        static void Main(string[] args)
        {
            for (int i = 0; i < 50; i++)
            {
                Thread T1 = new Thread(FirstThread);
                Thread T2 = new Thread(SecondThread);

                T1.Start();
                T2.Start();

                T1.Join();
                T2.Join();
                Console.WriteLine();
            }
        }

        static void FirstThread()
        {
            var randWait = new Random().Next(100);
            Thread.Sleep(randWait);
            count += 1;
            Console.WriteLine($"count in first thread is {count}");
        }

        static void SecondThread()
        {
            var randWait = new Random().Next(100);
            Thread.Sleep(randWait);
            count += 1;
            Console.WriteLine($"count in second thread is {count}");
        }
    }
}
