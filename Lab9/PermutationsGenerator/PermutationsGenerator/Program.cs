using System;

namespace PermutationsGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var ans = PermutationsGenerator.GeneratePermutations(input);
            ans.Sort();

            foreach(var permutation in ans)
            {
                Console.Write(permutation + " ");
            }
        }
    }
}
