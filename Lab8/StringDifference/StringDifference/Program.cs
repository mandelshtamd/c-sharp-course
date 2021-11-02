using System;

namespace StringDifference
{
    // Task 3
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "Hello";
            var s2 = "hello";
            var dist = LevenshteinDistance.CalculateDistance(s1, s2);

            Console.WriteLine(dist == 1
                ? $"Строки {s1} и {s2} отличаются на 1 символ."
                : $"Расстояние между строками {dist}");
        }
    }
}
