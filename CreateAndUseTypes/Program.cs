using System;

namespace CreateAndUseTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run: P5: Enumeratings Strings
            /*
            Strings.RunOriginalExample();
            Console.WriteLine("Modified String example");
            Strings.RunModifiedExample();
            */

            //Run P8: Longest Substring Without Repeating Characters
            int len = LongestSubString.LengthOfLongestSubstring("jbpnbwwd");
            Console.WriteLine(len);
        }
    }
}
