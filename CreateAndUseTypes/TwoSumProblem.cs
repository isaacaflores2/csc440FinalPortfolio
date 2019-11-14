using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    class TwoSumProblem
    {
        //P12: Reverse Words in a String II
        //Source: https://leetcode.com
        public static int[] TwoSum(int[] nums, int target)
        {            
            if(nums == null || nums.Length == 0)
            {
                return new int[] {-1,-1};
            }
            

            //This changes the orignal indexes
            //Array.Sort(nums);

            for(int i=0; i<nums.Length; i++)
            {
                if(i>= target)                
                    break;               
                
                for(int j =1; j <nums.Length; j++)
                {
                    if (j >= target)
                        break;

                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };
                }
            }
            return new int[] { -1, -1 };
        }
    }
}
