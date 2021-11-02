using System;
using System.Collections.Generic;
using System.Text;

namespace StringDifference
{
    public static class LevenshteinDistance
    {
        public static int CalculateDistance(string first, string second)
        {
            var firstLength = first.Length;
            var secondLength = second.Length;

            var dpDistance = new int[firstLength + 1, secondLength + 1];

            if (firstLength == 0)
                return secondLength;

            if (secondLength == 0)
                return firstLength;

            for (var i = 0; i <= firstLength; dpDistance[i, 0] = i++) { }
            for (var j = 0; j <= secondLength; dpDistance[0, j] = j++) { }

            for (var i = 1; i <= firstLength; i++)
            {
                for (var j = 1; j <= secondLength; j++)
                {
                    var cost = (second[j - 1] == first[i - 1]) ? 0 : 1;

                    dpDistance[i, j] = Math.Min(
                        Math.Min(dpDistance[i - 1, j] + 1, dpDistance[i, j - 1] + 1),
                        dpDistance[i - 1, j - 1] + cost);
                }
            }
            return dpDistance[firstLength, secondLength];
        }
    }
}
