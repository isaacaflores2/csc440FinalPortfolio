using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManageProgramFlow
{
    public static class ParallelTask
    {
        //P2: Use the Parallel class
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 1, Page: 16, Listing 1-16

        #region Original source code
        //This method shows two different ways to execute tasks in parallel
        public static void RunOriginalExample()
        {
            //This method uses the For function 
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
            }
            );

            //This method uses the ForEach function
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });

        }
        #endregion

        #region Modified code
        //This modified program calculates the same of three list sequential and in parallel
        public static void RunModifiedExample(int sizeOfList)
        {
            //Create a list with numbers 0 to sizeOfList           
            List<int> list = new List<int>();
            for(int i = 0; i< sizeOfList; i++)
            {
                list.Add(i);
            }

            //Calculates sums
            calcSumForThreeList(list, list, list);
            //The parallel method takes a little more time to setup, so you will only see the benefits for a list with a lot of numbers
            calcSumForThreeListInParallel(list, list, list);
        }
  
        public static void calcSumForThreeList(IEnumerable<int> list1, IEnumerable<int> list2, IEnumerable<int> list3)
        {
            long sum;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            //This will calculate the sums sequentially
            sum = calcSum(list1) + calcSum(list2) + calcSum(list3);
            
            timer.Stop();

            Console.WriteLine($"Sequential sum elapsed time: {timer.Elapsed.TotalSeconds}");
        }

        public static void calcSumForThreeListInParallel(IEnumerable<int> list1, IEnumerable<int> list2, IEnumerable<int> list3)
        {
            
            long sum = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();

            //This will calculate the sums in parallel
            IEnumerable<IEnumerable<int>> listToCalcSum = new List<IEnumerable<int>> { list1, list2, list3 };            
            Parallel.ForEach(listToCalcSum, list =>
            {
                sum += calcSum(list);
            });

            timer.Stop();


            Console.WriteLine($"Parallel sum elapsed time: {timer.Elapsed.TotalSeconds}");
        }


        public static long calcSum(IEnumerable<int> list)
        {
            long sum = 0;
            foreach(var element in list)
            {
                sum += element;
            }

            return sum;
        }

        #endregion

        #region Code output
        /*
            Sequential sum elapsed time: 0.0010674
            Parallel sum elapsed time: 0.0012668999999999998
            Sequential sum elapsed time: 0.0008755
            Parallel sum elapsed time: 0.0008263
            Sequential sum elapsed time: 0.0090901
            Parallel sum elapsed time: 0.0059041
         */
        #endregion
    }
}
