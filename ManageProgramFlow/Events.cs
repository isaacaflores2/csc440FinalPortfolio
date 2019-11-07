using System;
using System.Collections.Generic;
using System.Text;

namespace ManageProgramFlow
{
    class Events
    {
        //P5: Enumeratings Strings
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 2, Page: 163, Listing 2-95

        #region Original source code
        //This example shows how a string implements the IEnumerable interface and the fact that a string has an underlying array of chars     
        public static void RunOriginalExample()
        {
          
        }

        class MyArgs : EventArgs
        {
            public MyArgs(int value)
            {
                Value = value;
            }

            public int Value { get; set; }
        }

        class Pub
        {
            public EventHandler<MyArgs> OnChange = delegate { };

            public void Raise()
            {
                OnChange(this, new MyArgs(42));
            }
        }


        #endregion

        #region Modified code  
        //This example enumerates a string array and shows some basic string functions
        public static void RunModifiedExample()
        {
          
            
        }
        #endregion

        #region Code output
        /*
           
         */
        #endregion
    }

    
}
