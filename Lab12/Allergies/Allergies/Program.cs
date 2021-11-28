using System;

namespace Allergies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ToString() examples:");
            var mary = new Allergies("Mary");
            Console.WriteLine(mary.ToString());

            var joe = new Allergies("Joe", 65);
            Console.WriteLine(joe.ToString());

            var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");
            Console.WriteLine(rob.ToString());

            Console.WriteLine();
            Console.WriteLine("Let's delete rob's allergy to cats");
            rob.DeleteAllergy("Cats");
            Console.WriteLine(rob.ToString());
            Console.WriteLine("And let's add it back");
            rob.AddAlergy("Cats");
            Console.WriteLine(rob.ToString());
            Console.WriteLine($"Total rob's score is: {rob.Score}");
        }
    }
}
