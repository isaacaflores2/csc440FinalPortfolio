using System;
using ManageProgramFlow;
namespace csc440FinalPortfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run: P1: Creating a thread with the Thread class
            /*
            CreateThreads.RunOriginalExample();
            Console.WriteLine("");
            Console.WriteLine("Modified Create thread example");
            CreateThreads.RunModifiedExample();
            */

            //Run: P2: Run task in parallel
            /*
            ParallelTask.RunOriginalExample();
            ParallelTask.RunModifiedExample(1000);            
            ParallelTask.RunModifiedExample(10000);           
            ParallelTask.RunModifiedExample(100000);
            */

            //Run: P3: Async and Await example
            //AsyncAwait.RunModifiedExample();

            //Run: P4: Delegates example
            Delegates delegates = new Delegates();
            delegates.RunOriginalExample();
            Console.WriteLine("");
            Console.WriteLine("Modified Delegate example");
            delegates.RunModifiedExample();

        }
    }
}
