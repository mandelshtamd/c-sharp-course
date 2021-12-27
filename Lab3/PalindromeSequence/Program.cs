using System;
using System.Linq;

namespace PalindromeSequence
{
    class PalindromeSequence
    {
        public static long ReverseLong(long num)
        {
            long result = 0;
            while (num > 0)
            {
                result = result * 10 + num % 10;
                num /= 10;
            }
            return result;
        }

        public static Tuple<long, long> PalSeq(long palindrome)
        {
            long seed = 0;
            long steps = 0;

            for (long i = 1; i <= palindrome; i++)
            {
                long currentCandidate = i;
                while (currentCandidate < palindrome)
                {
                    currentCandidate += ReverseLong(currentCandidate);
                    steps++;
                }

                if (currentCandidate == palindrome)
                {
                    return new Tuple<long, long>(i, steps);
                }

                steps = 0;
            }
            return new Tuple<long, long>(seed, steps);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var palindrome = long.Parse(Console.ReadLine());
            var (seed, steps) = PalindromeSequence.PalSeq(palindrome);
            Console.WriteLine($"seed = {seed}, steps = {steps}");
        }
    }
}