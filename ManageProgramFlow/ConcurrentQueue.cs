using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    class ConcurrentQueue
    {
        //P7: Using a concurrent queue
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 1, Page: 28, Listing 1-32

        #region Original source code
        //This example shows how to use the basic Enqueue and Dequeue functions of a Concurrent queue 
        public static void RunOriginalExample()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if(queue.TryDequeue(out result))
            {
                Console.WriteLine("Dequeued {0}", result);
            }

        }

       
        #endregion

        #region Modified code  


        //This runs two seperate tasks that use the same queue to calculate the sum of the queue
        public static void RunModifiedExample()
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            int sum = 0;
            for(int i = 1; i < 100; i++)
            {
                queue.Enqueue(i);
                sum += i; 
            }

            //Both tasks will run concurrently on seperate threads with access to the same queue                
            var task1 = SumOfQueue(queue);
            var task2 =  SumOfQueue(queue);

            //This will wait for both task to complete
            Task.WaitAll(task1, task2);

            Console.WriteLine($"Task one returned {task1.Result} and Task two returned {task2.Result}");
            Console.WriteLine($"The actual sum of the queue is: {sum} and both task calculated: {task1.Result + task2.Result}");

        }

        //This async function runs the CalcSum method on a different thread and returns a Task<int>
        public static async Task<int> SumOfQueue(ConcurrentQueue<int> queue)
        {
            return await Task.Run( () => CalcSum(queue) );
        }

        //This function calculates the sum of the queue
        public static int CalcSum(ConcurrentQueue<int> queue)
        {
            int sum = 0;
            int value; 

            //This will Dequeue any remaining items
            while( queue.TryDequeue(out value))
            {
                sum += value;
                //Sleep was added here so Task1 would not calculate the entire sum before Task2 had a chance
                Thread.Sleep(10);
            }
            return sum;
        }


        #endregion

        #region Code output
        /*
            Dequeued 42  

            Modified Event example
            Task one returned 2417 and Task two returned 2533
            The actual sum of the queue is: 4950 and both task calculated: 4950


         */
        #endregion
    }
}
