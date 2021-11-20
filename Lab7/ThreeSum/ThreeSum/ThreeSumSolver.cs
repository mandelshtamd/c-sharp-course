using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeSum
{
    class ThreeSumSolver
    {
        public static List<int[]> ThreeSum(int[] nums)
        {
            var result = new List<int[]>();
            var len = nums.Length;
            if (len < 3) 
                return result;

            Array.Sort(nums);

            var dict = new Dictionary<int, int>();

            for (int i = 0; i < len; i++)
            {
                if (dict.ContainsKey(nums[i])) 
                    dict[nums[i]] = i;
                else 
                    dict.Add(nums[i], i);
            }

            for (int i = 0; i < len - 2; i++)
            {
                if (nums[i] > 0) 
                    break;

                if (i > 0 && nums[i] == nums[i - 1]) 
                    continue;

                for (int j = i + 1; j < len - 1; j++)
                {
                    if (j != i + 1 && nums[j] == nums[j - 1]) 
                        continue;

                    int numsk = 0 - nums[i] - nums[j];
                    if (dict.ContainsKey(numsk) && dict[numsk] > j)
                        result.Add(new int[] { nums[i], nums[j], numsk });
                }
            }

            return result;
        }
    }
}
