using System;
using System.Collections;

namespace FibonacciWord
{
    class Program
    {
        static string stringyFib(int number)
        {
            if (number < 2)
            {
                return "invalid";
            }

            var fibSeq = new string[number];
            fibSeq[0] = "b";
            fibSeq[1] = "a";

            for (int i = 2; i < number; i++)
            {
                fibSeq[i] = fibSeq[i - 1] + fibSeq[i - 2];
            }

            return string.Join(", ", fibSeq);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"stringyFib(1) -> {stringyFib(1)}");
            Console.WriteLine($"stringyFib(3) -> {stringyFib(3)}");
            Console.WriteLine($"stringyFib(7) -> {stringyFib(7)}");
        }
    }
}
