using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    static class LongestSubString
    {
        //P8: Longest Substring Without Repeating Characters
        //Source: https://leetcode.com/problems/longest-substring-without-repeating-characters/

        public static int LengthOfLongestSubstring(string s)
        {
            if (String.IsNullOrEmpty(s))
            {
                return 0; 
            }
            int max = 0;            
            HashSet<char> current = new HashSet<char>();

            int i = 0, j = 0;
            for(i = 0; i < s.Length; i++)
            {
                if (j == s.Length - 1 && i != 0)
                {
                    break;
                }

                for (j = i; j < s.Length; j++)
                {
                    if (current.Contains(s[j]))
                    {
                        if(current.Count > max)
                        {
                            max = current.Count;                            
                        }
                        current.Clear();
                        break;
                    }
                    else
                    {
                        current.Add(s[j]);                        
                    }
                }
            }
            
            if (current.Count > max)
            {
                max = current.Count;
            }

            return max;
        }                
    }
}
