using System;
using System.Collections.Generic;
using System.Text;

namespace CreateAndUseTypes
{
    class ImplementInterface
    {
        //P10: Instatiating a concrete type that implements an interface
        //Source: Kort, W. de. (2013). Exam ref 70-483: programming in C#. Redmond, WA: Microsoft Press.
        //Chapter: 2, Page: 127, Listing 2-44

        #region Original source code
        //This example shows how to implement an interface
        public static void RunOriginalExample()
        {
            //Create an IAnimal reference variable for a Dog object
            IAnimal animal = new Dog();
            MoveAnimal(animal);
        }

        interface IAnimal
        {
            //Only method required to implement the interface
            void Move();
        }

        class Dog : IAnimal
        {
            //Implicit implementation of the IAnimal Move method
            public void Move() {
                Console.WriteLine("Dog Moves!");
            }

            public void Bark() {
                Console.WriteLine("Dog Barks!");
            }
        }

        //Create method that accepts IAnimal parameter
        static void MoveAnimal(IAnimal animal)
        {
            animal.Move();
        }

        #endregion

        #region Modified code  

        //This modified example shows the difference between explicit and implicit implementations
        public static void RunModifiedExample()
        {
            Cat cat = new Cat();
            MakeAnimalNoiseAndMove(cat);
        }

        public class Cat : IAnimal
        {
            //Explicit implementation of the Move method
            void IAnimal.Move()
            {
                Console.WriteLine("Cat Moves");
            }

            public void Meow()
            {
                Console.WriteLine("Cat Meows");
            }
        }

        static void MakeAnimalNoiseAndMove(Cat cat)
        {
            cat.Meow();
            //This is not allow because the Cat class explicitly implements the Move method
            //cat.Move();

            //You must use a reference variable of type IAnimal to call the move method for the cat object
            IAnimal animal = (IAnimal)cat;
            animal.Move(); 
        }

        #endregion

        #region Code output
        /*
            Dog Moves!
            Modified String example
            Cat Meows
            Cat Moves
         */
        #endregion
    }
}

