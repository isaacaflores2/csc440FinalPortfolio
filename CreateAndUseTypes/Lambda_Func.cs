using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateAndUseTypes
{
    public static class MyExtensions
    {
        public static IEnumerable<TResult> Concatenate<TSource, TResult>(this IEnumerable<TSource> source, IEnumerable<TSource> sourceToConcatenate,
          Func<TSource, TSource, TResult> concatenator)
        {
            IEnumerable<TResult> result = new List<TResult>();

            if (source.Count() != sourceToConcatenate.Count())
            {
                throw new ArgumentException("Source and sourceToConcatenate must be the same lenght");
            }

            result = source.Zip(sourceToConcatenate, concatenator);

            return result;
        }
    }

    class Lambda_Func
    {
        //P15: Func<T,TResult> Delegate
        //Source: https://docs.microsoft.com/en-us/dotnet/api/system.func-2?view=netframework-4.8
        

        #region Original source code
        //This example shows how the IEnuerable interface allows you to use a foreach loop
        public static void RunOriginalExample()
        {
            // Declare a Func variable and assign a lambda expression to the  
            // variable. The method takes a string and converts it to uppercase.
            Func<string, string> selector = str => str.ToUpper();

            // Create an array of strings.
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);

            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);
        }
       
        #endregion

        #region Modified code  
        //This example creates an extension method to Create a Select function which accepts to two string paramets and returns one concatenated string
        public static void RunModifiedExample()
        {
            //Declare a Func variable and assign it to a lambda expression that accepts two strings and return their concatenation
            Func<string, string, string> concatenator = (s1, s2) => s1 + s2;

            string[] words = { "orange", "apple", "Article", "elephant" };
            string[] otherWords = { "Dog", "ToApples", "ToRead", "s are scared of mice" };

            var concatenatedWords = words.Concatenate(otherWords, concatenator);

            foreach(var concatWord in concatenatedWords)
            {
                Console.WriteLine(concatWord);
            }
        }
        #endregion

        #region Code output
        /*
            ORANGE
            APPLE
            ARTICLE
            ELEPHANT
            Modified example
            orangeDog
            appleToApples
            ArticleToRead
            elephants are scared of mice
         */
        #endregion
    }
}
