using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQTest_AsEnumerable
{
    class Program
    {
        class Animal
        {

        }
        class Dog : Animal { }

        /*
         * 
            typeof takes a type name (which you specify at compile time).
            GetType gets the runtime type of an instance.
            is returns true if an instance is in the inheritance tree.
         */
        static void Main(string[] args)
        {
            var dog = new Dog();
            Animal animal = dog;

            Console.WriteLine(typeof(Dog).Name);
            Console.WriteLine(animal.GetType().Name);

        }
    }
}

