using System;
using System.Collections.Generic;

namespace SortCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var personsToCompare = new List<Person>
            {
                new Person("George", 15),
                new Person("Anna", 42),
                new Person("Valeria", 8),
                new Person("Mark", 15),
                new Person("Anka", 32)
            };

            personsToCompare.Sort(new PersonAgeComparer());
            Console.WriteLine("List of people sorted by age:");
            foreach (var person in personsToCompare)
            {
                Console.WriteLine($"Person(Age={person.Age}, Name={person.Name})");
            }

            Console.WriteLine();

            personsToCompare.Sort(new PersonNameComparer());
            Console.WriteLine("List of people sorted by name:");
            foreach (var person in personsToCompare)
            {
                Console.WriteLine($"Person(Name={person.Name}, Age={person.Age})");
            }
        }
    }
}
