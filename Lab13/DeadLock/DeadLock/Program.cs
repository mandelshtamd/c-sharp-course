using System;
using System.Threading;

namespace DeadLock
{
    class Program
    {
        static object firstResource = new object();
        static object secondRecourse = new object();


        static void Main(string[] args)
        {
            Thread thread1 = new Thread(FirstThreadWorker);
            Thread thread2 = new Thread(SecondThreadWorker);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        static void FirstThreadWorker()
        {
            lock (firstResource)
            {
                Console.WriteLine("first resource locked by first thread");
                Thread.Sleep(500);
                lock (secondRecourse)
                {
                    Console.WriteLine("Thanks for a day without deadlocks!");
                }
            }
        }

        static void SecondThreadWorker()
        {
            lock (secondRecourse)
            {
                Console.WriteLine("second resource locked by second thread");
                Thread.Sleep(500);
                lock (firstResource)
                {
                    Console.WriteLine("Thanks for a day without deadlocks!");
                }
            }
        }
    }
}
