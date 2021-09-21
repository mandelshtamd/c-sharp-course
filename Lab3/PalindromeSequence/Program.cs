using System;
using System.Linq;

namespace PalindromeSequence
{
    class PalindromeSequence
    {
        public static int ReverseInt(int num)
        {
            var result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        public static Tuple<int, int> PalSeq(int palindrome)
        {
            int seed = 0;
            int steps = 0;

            for (int i = 1; i <= palindrome; i++)
            {
                var currentCandidate = i;
                while (currentCandidate < palindrome)
                {
                    currentCandidate += ReverseInt(currentCandidate);
                    steps++;
                }

                if (currentCandidate == palindrome)
                {
                    return new Tuple<int, int>(i, steps);
                }

                steps = 0;
            }
            return new Tuple<int, int>(seed, steps);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var palindrome = int.Parse(Console.ReadLine());
            var (seed, steps) = PalindromeSequence.PalSeq(palindrome);
            Console.WriteLine($"seed = {seed}, steps = {steps}");
        }
    }
}
