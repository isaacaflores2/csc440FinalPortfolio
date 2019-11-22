using System;
using System.Collections.Generic;
using System.Text;


namespace CreateAndUseTypes
{
    class Lambda_Action
    {
        //P16: Statement lambdas
        //Source: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions


        #region Original source code
        //This example creates a statement lamba and assigns the statement to an Action<string> variable
        public static void RunOriginalExample()
        {
            Action<string> greet = name =>
            {
                string greeting = $"Hello {name}!";
                Console.WriteLine(greeting);
            };

            //This passes the string "World" as the name parameter for the action
            greet("World");        

        }

        #endregion

        #region Modified code  
        //This modified example will create a method that accepts Action as a parameter
        public static void RunModifiedExample()
        {
            Action<string> printMessageWithHelloWorldInSpanish = (msg) => Console.WriteLine("Hola Mundo! " + msg);

            HelloWorldAction(printMessageWithHelloWorldInSpanish);
        }

        public static void HelloWorldAction(Action<string> action)
        {
            action("Hello World");
        }

        #endregion

        #region Code output
        /*
            Hello World!
            Modified example
            Hola Mundo! Hello World
         */
        #endregion
    }
}
