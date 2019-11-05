using System;
using System.Collections.Generic;
using System.Text;

namespace ManageProgramFlow
{
    public class Delegates
    {
        //P1: Create and use delegates
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 1, Page: 57, Listing 1-75

        #region Original source code
        //This example declareds a delegate and calls two methods on it. It demonstrates the importance of being able create methods 
        //that match the delegate method signature
        public void RunOriginalExample()
        {
            UseDelegate();
        }

        //Delegate returns an int and accepts two int parameters
        public delegate int Calculate(int x, int y);

        //These methods must match the signature of the Calculate class (return an int and accept two int parameters)
        public int Add(int x, int y) { return x + y; }
        public int Multiply(int x, int y) { return x * y; }

        public void UseDelegate()
        {
            //This adds one method to the deleage
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            //This overwrites the previous subscribed delegate (Add)
            calc = Multiply;
            Console.WriteLine(calc(3,4));
        }
        #endregion

        #region Modified code
        //This modified example shows how you can use multicast delegates (combine delegates)

        //This method prints the intermediate sum to the console combined delegates only return the value from the last method
        public int Add2(int x, int y) {
            int sum = x + y;
            Console.WriteLine(sum); 
            return sum; 
        }

        public int Multiply2(int x, int y)
        {
            int diff = x - y;
            Console.WriteLine(diff);
            return diff;
        }
        public int Divide(int x, int y) {
            int div = x / y;
            Console.WriteLine(div);
            return div;
        }

        //This method combines the delegates
        public void RunModifiedExample()
        {

            //Here we add the Add method to the delegate
            Calculate doThreeCalcs = Add2;

            //Here we use the += operator to add the second delegate
            //This is cause the delegate to call Add2 and Multiply2 when we call it
            doThreeCalcs += Multiply2;

            //We  add the third method. 
            doThreeCalcs += Divide;

            //Invoke the delegate this will call all three functions
            doThreeCalcs(5, 5);
        }



        #endregion

        #region Code output
        /*
             7
            12

            Modified Delegate example
            10
            0
            1

         */
        #endregion
}
}

