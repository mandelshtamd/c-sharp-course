using System;

namespace MaxyMinny
{
    class Program
    {

        static void Main(string[] args)
        {
            var input = 9340239520346;
            var ans = MaxyMinnySolver.Solve(input);
            Console.WriteLine($"from {input} we can get max={ans.Item1}, min={ans.Item2}");
        }
    }
}
