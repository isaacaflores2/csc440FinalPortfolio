using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    class OverrideAndNewMethod
    {
        //P13: Overriding a virtual method
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 2, Page: 129, Listing 2-47

        #region Original source code
        //This example shows how to override a virtual method
        public static void RunOriginalExample()
        {
            //Create an instance of the derived class and call the execute method
            Derived derivedClass = new Derived();
            derivedClass.Execute();
            
        }

        class Base
        {
            public  virtual void Execute()
            {
                Console.WriteLine("Base class executes");
            }
        }

        class Derived : Base
        {
            //Add custom functionality to the execute statement using the override keyword
            public override void Execute()
            {
                Console.WriteLine("Derived class executes");
            }

            private void Log(string message)
            {
                Console.WriteLine("Log: derived class");
            }
        }

        #endregion

        #region Modified code  
        //This example shows the difference between override and the new
        public static void RunModifiedExample()
        {
            //Create an instance of the ModifiedDerived class with a Base class reference
            //Since we used the new keyword to change the Execute method this will call the Execute method from the Base class
            Base modified = new ModifiedDerived();
            Base derived = new Derived();
                
            modified.Execute();
            derived.Execute();
        }

        class ModifiedDerived : Base
        {
            //Use the new keyword to hide the base class implementation
            public new void Execute()
            {
                Console.WriteLine("Modified Derived class executes");
            }

            private void Log(string message)
            {
                Console.WriteLine("Log: derived class");
            }
        }

        #endregion

        #region Code output
        /*
            Derived class executes
            Modified example
            Base class executes
            Derived class executes

         */
        #endregion
    }
}

