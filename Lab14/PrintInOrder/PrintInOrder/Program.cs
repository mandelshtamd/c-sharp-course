using System;
using System.Threading;

namespace PrintInOrder
{
    class Program
    {
        static Foo testFoo = new Foo();

        static void Main(string[] args)
        {
            Thread threadA = new Thread(testFoo.first);
            Thread threadB = new Thread(testFoo.second);
            Thread threadC = new Thread(testFoo.third);

            var input = Console.ReadLine();
            var parsedInput = input.Substring(1, input.Length - 2).Split(",");

            foreach(var ind in parsedInput)
            {
                if (ind == "1")
                {
                    threadA.Start();
                }
                else if (ind == "2")
                {
                    threadB.Start();
                }
                else
                {
                    threadC.Start();
                }
            }

            threadA.Join();
            threadB.Join();
            threadC.Join();
        }
    }
}
