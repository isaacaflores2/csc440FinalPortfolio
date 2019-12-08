using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateAndUseTypes
{
    class TwoSumProblem
    {
        //P12: TwoSum problem
        //Source: https://leetcode.com
        public static int[] TwoSum(int[] nums, int target)
        {            
            if(nums == null || nums.Length == 0)
            {
                return new int[] {-1,-1};
            }

            var numsDict = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int requiredKey = target - nums[i];
                if (numsDict.ContainsKey(requiredKey))
                {
                    int requiredIndex = numsDict[requiredKey];
                    return new int[] { i, requiredIndex };
                }
                numsDict[nums[i]] =  i;
            }
           
            return new int[] { -1, -1 };
        }
    }
}
