using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    public class Person : Nameble
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public Person(string name)
        {
            Name = name;
        }
    }
}