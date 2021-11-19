using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        public static string ConcatNames(List<Nameble> namebleList, char delimiter)
        {
            if (namebleList == null) 
                throw new ArgumentNullException();

            return namebleList.Skip(3).Where(x => !string.IsNullOrWhiteSpace(x.Name)).Select(x => x.Name).Aggregate((i, j) => i + delimiter + j);
        }

        static void Main(string[] args)
        {
            var people = new List<Nameble>() { new Person("John"), new Person("Cate"), new Person("Viktor"),
                                        new Person("Nick"), new Person("Jane")};

            var delimiter = ',';
            var concatResult = ConcatNames(people, delimiter);

            Console.WriteLine(concatResult);
        }
    }
}
