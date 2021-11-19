using System;
using System.Linq;

namespace Task3
{
    class Program
    {
        public static char[] PunctiationSigns = (" .,?!—-;:\n").ToCharArray();

        public static void GroupBySameLength(string sentence)
        {
            if (sentence == null) 
                throw new ArgumentNullException();

            var words = sentence.Split(PunctiationSigns, StringSplitOptions.RemoveEmptyEntries);
            var groups = words
                .GroupBy(x => x.Length)
                .Select(x => (WordLength: x.Key, WordCount: x.Count(), Content: x))
                .OrderByDescending(x => x.WordCount);

            foreach (var group in groups)
            {
                Console.WriteLine($"Длина: {group.WordLength}, Количество: {group.WordCount} ");
                foreach(var word in group.Content)
                {
                    Console.WriteLine(word);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            var example1 = "Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена";
            Console.WriteLine($"For example \"{example1}\" we get:");
            Console.WriteLine();
            GroupBySameLength(example1);
        }
    }
}
