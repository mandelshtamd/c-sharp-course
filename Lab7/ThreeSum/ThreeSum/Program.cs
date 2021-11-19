using System;

namespace ThreeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var example1 = new int[] { 0, 1, -1, -1, 2 };
            Console.Write("For input { 0, 1, -1, -1, 2 } we get answers: ");
            var ans = ThreeSumSolver.ThreeSum(example1);

            foreach(var ar in ans)
            {
                Console.Write("{");
                foreach(var el in ar) {
                    Console.Write($"{el} ");
                }
                Console.Write("} ");
            }
        }
    }
}
