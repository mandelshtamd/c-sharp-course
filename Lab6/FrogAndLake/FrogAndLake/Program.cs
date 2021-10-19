using System;
using System.Collections.Generic;

namespace FrogAndLake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("First example from task");
            var example1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            var lake = new Lake(example1);

            foreach (var stone in lake)
            {
                Console.WriteLine($"Frog jumped to {stone} stone");
            }

            Console.WriteLine("Second example from task");
            var example2 = new List<int> { 13 , 23 , 1 , -8 , 4 , 9 };
            lake = new Lake(example2);

            foreach (var stone in lake)
            {
                Console.WriteLine($"Frog jumped to {stone} stone");
            }
        }
    }
}
