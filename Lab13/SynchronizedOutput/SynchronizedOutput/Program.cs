using System;
using System.Threading;

namespace SynchronizedOutput
{
    class Program
    {
        private static Mutex mutex = new Mutex();
        // using this to garantee that first thread runs before second
        private static volatile bool rightOrderVariable = false;

        static void Main(string[] args)
        {
            Thread T1 = new Thread(FirstPrinter);
            Thread T2 = new Thread(SecondPrinter);

            T1.Start();
            T2.Start();
        }

        static void FirstPrinter()
        {
            for (int i = 0; i < 10; i++)
            {
                mutex.WaitOne();

                if (i == 0)
                {
                    rightOrderVariable = true;
                }

                Console.WriteLine($"{i}-th output in T1");
                Console.WriteLine();
                mutex.ReleaseMutex();
            }
        }

        static void SecondPrinter()
        {
            while(!rightOrderVariable) { }

            for (int i = 0; i < 10; i++)
            {
                mutex.WaitOne();
                Console.WriteLine($"{i}-th output in T2");
                Console.WriteLine();
                mutex.ReleaseMutex();
            }
        }
    }
}
