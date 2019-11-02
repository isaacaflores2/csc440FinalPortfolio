﻿using System;
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
            ParallelTask.RunOriginalExample();
            ParallelTask.RunModifiedExample(1000);            
            ParallelTask.RunModifiedExample(10000);           
            ParallelTask.RunModifiedExample(100000);
        }
    }
}
