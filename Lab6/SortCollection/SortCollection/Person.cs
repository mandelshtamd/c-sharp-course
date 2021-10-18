using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace SortCollection
{
    public class Person
    {
        public string Name
        {
            get;
        }

        public int Age
        {
            get;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class PersonNameComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.Name.Length == y.Name.Length) return String.Compare(x.Name.Substring(0, 1), y.Name.Substring(0, 1), StringComparison.OrdinalIgnoreCase);
            return x.Name.Length.CompareTo(y.Name.Length);
        }
    }

    public class PersonAgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }
    }
}
