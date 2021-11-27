using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PermutationsGenerator
{
    public static class PermutationsGenerator
    {
        public static List<string> GeneratePermutations(string input)
        {
            var output = new List<string>();
            if (input.Length == 1)
            {
                output.Add(input);
            }
            else
            {
                foreach (var c in input)
                {
                    var tail = input.Remove(input.IndexOf(c), 1);
                    foreach (var tailPerms in GeneratePermutations(tail))
                    {
                        output.Add(c + tailPerms);
                    }
                }
            }
            return output;
        }
    }
}
