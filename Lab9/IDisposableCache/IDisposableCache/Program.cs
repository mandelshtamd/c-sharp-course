using System;
using System.Collections.Generic;
using System.Threading;

namespace IDisposableCache
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First example. Clear after adding new element.");
            var cacheSize = 8;
            var cache = new Cache<IDisposableList>(cacheSize);
            Console.WriteLine($"Cache size = {cacheSize}");

            for(var i = 0; i < 20; i++)
            {
                Console.WriteLine($"Added {i}-th element...");
                cache.Add(i, new IDisposableList(8, i));
            }

            Console.WriteLine();
            Console.WriteLine("Let's ensure that all \"old\" elements will be cleared if they are \"old\"");
            Thread.Sleep(2000);
            cache.Clear();
            Console.WriteLine($"Now cache size is {cache.ElementsInCache()}");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Second example. Clearing before garbage collector starts.");
            for (int i = 0; i < 10000000; i++)
            {
                if (i % 1000000 == 0)
                {
                    Console.WriteLine($"Allocating ({(i / 100000) + 10}%)");
                }
                
                var elem = new List<int>(10000);
            }
        }
    }
}
