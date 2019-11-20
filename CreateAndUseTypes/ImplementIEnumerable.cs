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
        //Chapter: 2, Page: 135, Listing 2-56

        #region Original source code
        //This example shows how the IEnuerable interface allows you to use a foreach loop
        public static void RunOriginalExample()
        {
            var personArray = new Person[] { new Person("Isaac", "Flores"), new Person("John", "Doe") };
            var people = new People(personArray);          

            foreach(var person in people)
            {
                Console.WriteLine($"{person.FirstName}, {person.LastName}");
            }
        }

        //Person class that contains firstname and lastname
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

        //People class the implements the IEnumerable interface and contains an array of person objects
        public class People : IEnumerable<Person>
        {            
            public People(Person[] people)
            {
                this.people = people;
            }

            //This method uses the yield operator to return the next Person object
            public IEnumerator<Person> GetEnumerator()
            {
                for(int index=0; index < people.Length; index++)
                {
                    yield return people[index];
                }
            }

            //IEnumerable method: This method explicitly implements the IEnumerable method amd delegates to the class GetEnumerator method to yield the next Person object
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator(); 
            }

            Person[] people;
        }



        #endregion

        #region Modified code  
        //This example uses the decorator pattern to add logging in the GetEnumerator method
        public static void RunModifiedExample()
        {
            var personArray = new Person[] { new Person("Isaac", "Flores"), new Person("John", "Doe") };
            var people = new DecoratedPeople(personArray);

            //No need to log in the foreach loop
            foreach (var person in people) ;
                        
        }

        //DecoratePeople class the implements the IEnumerable interface and contains an array of person objects and logs during the GetEnumerator method
        public class DecoratedPeople : IEnumerable
        {
            public DecoratedPeople(Person[] people)
            {
                this.people = people;
            }

            //This method adds a little logging functionality 
            IEnumerator GetEnumerator()
            {
                for(int i =0; i < people.Length; i++)
                {
                    var person = people[i];
                    Console.WriteLine($"{person.FirstName}, {person.LastName}");
                    yield return person;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator(); 
            }

            Person[] people; 
        }

        #endregion

        #region Code output
        /*
             Isaac, Flores
            John, Doe
            Modified example
            Isaac, Flores
            John, Doe
         */
        #endregion
    }
}
