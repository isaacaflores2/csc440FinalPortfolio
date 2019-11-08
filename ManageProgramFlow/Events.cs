using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManageProgramFlow
{
    class Events
    {
        //P6: Manually raising events with exception handling
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 1, Page: 65, Listing 1-86

        #region Original source code
        //This example shows properly handle exceptions when invoking delegates of an event   
        public static void RunOriginalExample()
        {
            CreateAndRaise();
        }
     
        class Pub
        {
            //Create and initialize an event of type EventHandler; The assignment prevents the need for a null check later              
            public event EventHandler OnChange = delegate { };

            public void Raise()
            {
                var exceptions = new List<Exception>();
                
                foreach(Delegate handler in OnChange.GetInvocationList())
                {
                    try
                    {
                        //Invoke the subscribe Event Handler
                        handler.DynamicInvoke(this, EventArgs.Empty);
                    }
                    catch(Exception ex)
                    {
                        exceptions.Add(ex);
                    }
                }

                //This Any method is an extension method that requires the System.Linq library
                if (exceptions.Any())
                {
                    //Throw an exception if there are any
                    throw new AggregateException(exceptions);
                }

            }
        }

        public static void CreateAndRaise()
        {
            Pub p = new Pub();

            //Use lambda functions to create EventHandlers and subscribe
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 Called");
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 2 Called");
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 Called");

            try
            {
                //This will call all the functions
                p.Raise();
            }
            catch(AggregateException ex)
            {
                //All other functions that did not throw an exception have successfully completed at this point
                Console.WriteLine(ex.InnerExceptions.Count);
            }
        }

        #endregion

        #region Modified code  


        //This example enumerates a string array and shows some basic string functions
        public static void RunModifiedExample()
        {
            CreateAndRaiseModified();            
        }

        public static void CreateAndRaiseModified()
        {
            Pub p = new Pub();

            //Use lambda functions to create EventHandlers, subscribe, and throw exceptions
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 1 Called");
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 2 Called");
            p.OnChange += (sender, e) => throw new NullReferenceException("Should have used a nullable type!");
            p.OnChange += (sender, e) => Console.WriteLine("Subscriber 3 Called");
            p.OnChange += (sender, e) => throw new ArithmeticException("Oh Isaac, did you really try to divide by zero?");

            try
            {
                p.Raise();
            }
            catch (AggregateException ex)
            {

                Console.WriteLine("Total exceptions: "  + ex.InnerExceptions.Count);

                //This will go through every inner exception and show the corresponding error message
                foreach(var e in ex.InnerExceptions)
                {                    
                    Console.WriteLine(e.InnerException + "\n");                    
                }
            }
        }
        #endregion

        #region Code output
        /*
            Subscriber 1 Called
            Subscriber 2 Called
            Subscriber 3 Called

            Modified Event example
            Subscriber 1 Called
            Subscriber 2 Called
            Subscriber 3 Called
            Total exceptions: 2
            System.NullReferenceException: Should have used a nullable type!
                at ManageProgramFlow.Events.<>c.<CreateAndRaiseModified>b__4_2(Object sender, EventArgs e) in C:\Users\izmac\source\repos\csc440FinalPortfolio\ManageProgramFlow\Events.cs:line 92

            System.ArithmeticException: Oh Isaac, did you really try to divide by zero?
                at ManageProgramFlow.Events.<>c.<CreateAndRaiseModified>b__4_4(Object sender, EventArgs e) in C:\Users\izmac\source\repos\csc440FinalPortfolio\ManageProgramFlow\Events.cs:line 94

         */
        #endregion
    }


}
