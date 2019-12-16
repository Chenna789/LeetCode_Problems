using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    partial class LeetCodePractice
    {
        public int[] TwoSumApproach1(int[] nums, int target)
        {
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = i + 1; j < nums.Length; j++)
                {
                    int sum = nums[i] + nums[j] - target;
                    if (sum == 0)
                        return new int[] { i, j };
                }
            }
            return null;
        }
        public int[] TwoSumApproach2(int[] nums, int target)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                int num = nums[i];
                if(dictionary.TryGetValue(target - num, out int index))
                {
                    return new int[] { index, i };
                }
                dictionary[num] = i;
            }
            return null;
        }
    }
}
