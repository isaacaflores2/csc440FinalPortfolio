using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ManageProgramFlow
{
    public class CreateThreads
    {
        //P1: Creating a thread with the Thread class
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 1, Page: 4, Listing 1-1

        #region Original source code
        //This method creates a new instance of a thread by passing the Thread constructor an instance of a ThreadStart delegate. 
        //The program then runs the thread, does some example work, and waits for the thread to finish by calling the join method. 
        public static void RunOriginalExample()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t.Join();
        }
        
        //Method that is run in a seperate thread
        public static void ThreadMethod()
        {
            for(int i =0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(0);
            }
        }
        #endregion

        #region Modified code
        //This modified program runs two threads and passes the worker thread a parameter to allow us to distinguish the threads
        public static void RunModifiedExample()
        {
            
            Thread t1 = new Thread(() => ModifiedThreadMethod(1));
            Thread t2 = new Thread(() => ModifiedThreadMethod(2));
            t1.Start();
            t2.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }

            t1.Join();
            t2.Join();
        }

        //Modified worker method with a thread id and a unique console message
        public static void ModifiedThreadMethod(int threadId)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc[{1}]: {0}", i, threadId);
                Thread.Sleep(0);
            }
        }
        #endregion

        #region Code output
        /*
            ThreadProc: 0
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            ThreadProc: 1
            ThreadProc: 2
            ThreadProc: 3
            ThreadProc: 4
            ThreadProc: 5
            ThreadProc: 6
            ThreadProc: 7
            ThreadProc: 8
            ThreadProc: 9

            Modified Create thread example
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            Main thread: Do some work.
            ThreadProc[2]: 0
            ThreadProc[2]: 1
            ThreadProc[2]: 2
            ThreadProc[2]: 3
            ThreadProc[2]: 4
            ThreadProc[2]: 5
            ThreadProc[2]: 6
            ThreadProc[2]: 7
            ThreadProc[2]: 8
            ThreadProc[2]: 9
            ThreadProc[1]: 0
            ThreadProc[1]: 1
            ThreadProc[1]: 2
            ThreadProc[1]: 3
            ThreadProc[1]: 4
            ThreadProc[1]: 5
            ThreadProc[1]: 6
            ThreadProc[1]: 7
            ThreadProc[1]: 8
            ThreadProc[1]: 9
         */
        #endregion
    }
}
