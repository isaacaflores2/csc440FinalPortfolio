using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    class ImplementIEnumerable
    {
        //P14: Implementing IEnumerable<T> 
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 2, Page: 129, Listing 2-47

        #region Original source code
        //This example shows how to override a virtual method
        public static void RunOriginalExample()
        {
           
        }

        public class Person
        {
            public Person(String firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; }
            public string LastName { get; }
        }

        public class People : IEnumerable<Person>
        {
            public IEnumerator<Person> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }



        #endregion

        #region Modified code  
        //This example shows the difference between override and the new
        public static void RunModifiedExample()
        {
          
        }


        #endregion

        #region Code output
     
        #endregion
    }
}
