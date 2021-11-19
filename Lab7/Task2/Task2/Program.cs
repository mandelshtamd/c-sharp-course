using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        public static List<Nameble> GetLongNamesUsers(List<Nameble> users)
        {
            if (users == null) 
                throw new ArgumentNullException();

            return users.Where((x, index) => x.Name.Length > index).ToList();
        }

        static void Main(string[] args)
        {
            var people = new List<Nameble>() { new Person("John"), new Person("Cate"), new Person("Ai"),
                                        new Person("Nick"), new Person("Xi")};

            Console.Write("input list: ");
            for (var i = 0; i < people.Count; i++)
            {
                Console.Write($"{people[i].Name}(index={i}, name size = {people[i].Name.Length}) ");
            }
            Console.WriteLine();


            var result = GetLongNamesUsers(people);
            Console.Write("result list: ");
            for (var  i = 0; i < result.Count; i++)
            {
                Console.Write(result[i].Name + ' ');
            }
            Console.WriteLine();
        }
    }
}
