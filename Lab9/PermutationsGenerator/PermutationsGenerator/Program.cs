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

            // для подобного вывода гораздо эффективнее использовать String.Join метод:
            // https://docs.microsoft.com/ru-ru/dotnet/api/system.string.join?view=net-6.0
            foreach(var permutation in ans)
            {
                Console.Write(permutation + " ");
            }
        }
    }
}
