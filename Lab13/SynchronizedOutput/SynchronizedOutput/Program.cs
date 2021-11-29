using System;
using System.Threading;

namespace SynchronizedOutput
{
    class Program
    {
        private static readonly Semaphore firstSemaphore = new Semaphore(1, 1);
        private static readonly Semaphore secondSemaphore = new Semaphore(0, 1);

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
                firstSemaphore.WaitOne();

                Console.WriteLine($"{i}-th output in T1");
                Console.WriteLine();

                secondSemaphore.Release();
            }
        }

        static void SecondPrinter()
        {

            for (int i = 0; i < 10; i++)
            {
                secondSemaphore.WaitOne();

                Console.WriteLine($"{i}-th output in T2");
                Console.WriteLine();

                firstSemaphore.Release();
            }
        }
    }
}
