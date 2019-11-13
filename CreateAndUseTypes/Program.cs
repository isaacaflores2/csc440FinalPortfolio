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
            /*
            int len = LongestSubString.LengthOfLongestSubstring("jbpnbwwd");
            Console.WriteLine(len);
            */

            //Run P9: Implementing an implicit and explicit conversion operator
            /*
            ExplicitOperator.RunOriginalExample();
            ExplicitOperator.RunModifiedExample();
            */

            //Run P10: Instatiating a concrete type that implements an interface
            ImplementInterface.RunOriginalExample();
            Console.WriteLine("Modified String example");
            ImplementInterface.RunModifiedExample();
        }
    }
}
