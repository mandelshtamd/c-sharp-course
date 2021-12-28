using System;
using System.Collections.Generic;
using System.Threading;

namespace SleepingHairdresser
{
    class Program
    {
        public static Queue<int> customers = new Queue<int>();

        static void Main(string[] args)
        {
            Thread barber = new Thread(Barber);
            Thread customer = new Thread(Customer);
            barber.Start();
            customer.Start();

            barber.Join();
            customer.Join();
        }

        private static void Barber()
        {
            while (true)
            {
                Thread.Sleep(500);
                if (customers.Count > 0)
                {
                    Console.WriteLine($"I must wake up and cut {customers.Count} heads");
                    lock (customers)
                    {
                        customers.Dequeue();
                    }
                }
                else
                {
                    Console.WriteLine("I'm Sleeping");
                }
            }
        }

        private static void Customer()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (customers.Count < 5)
                {
                    Console.WriteLine($"My turn, {customers.Count} people left");
                    lock (customers)
                    {
                        customers.Enqueue(1);
                    }
                }

                else
                {
                    Console.WriteLine("Too many people, I'll come back later");
                }

            }
        }
    }
}
