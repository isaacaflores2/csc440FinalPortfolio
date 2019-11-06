using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    public static class Strings
    {
        //P5: Enumeratings Strings
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 2, Page: 163, Listing 2-95

        #region Original source code
        //This example shows how a string implements the IEnumerable interface and the fact that a string has an underlying array of chars     
        public static void RunOriginalExample()
        {
            string value = "My Custom value";
            foreach (char c in value)
                Console.WriteLine(c);
        }


        #endregion

        #region Modified code  
        //This example enumerates a string array and shows some basic string functions
        public static void RunModifiedExample()
        {
            //One of the elements in the string array is created using the constant String.Empty static member
            string[] words = new string[] {"Hello", "World", "", "Goodbye", "World", String.Empty, "Hey", "World I'm back!" };
            foreach(string word in words)
            {
                //Here we use the IsNUllOrEmpty class to easily check if the string is null or empty
                if(string.IsNullOrEmpty(word))
                {
                    Console.WriteLine("Empty String");
                    continue;
                }

                foreach (char c in word)
                {
                    Console.Write(c);
                }

                //Escaped tab character in a strings
                Console.WriteLine("\t");

            }
        }
        #endregion

        #region Code output
        /*
            M
            y

            C
            u
            s
            t
            o
            m

            v
            a
            l
            u
            e
            Modified String example
            Hello
            World
            Empty String
            Goodbye
            World
            Empty String
            Hey
            World I'm back!
         */
        #endregion
    }
}
