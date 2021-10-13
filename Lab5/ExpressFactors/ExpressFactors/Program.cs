using System;

namespace ExpressFactors
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"ExpressFactors(2) -> {Solution.ExpressFactors(2)}");
            Console.WriteLine($"ExpressFactors(4) -> {Solution.ExpressFactors(4)}");
            Console.WriteLine($"ExpressFactors(10) -> {Solution.ExpressFactors(10)}");
            Console.WriteLine($"ExpressFactors(60) -> {Solution.ExpressFactors(60)}");

            Console.WriteLine($"ExpressFactors(49) -> {Solution.ExpressFactors(49)}");
            Console.WriteLine($"ExpressFactors(16) -> {Solution.ExpressFactors(16)}");
            Console.WriteLine($"ExpressFactors(10000) -> {Solution.ExpressFactors(10000)}");
            Console.WriteLine($"ExpressFactors(512) -> {Solution.ExpressFactors(512)}");

        }
    }
}
