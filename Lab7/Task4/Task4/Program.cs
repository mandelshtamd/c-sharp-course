using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4
{
    class Program
    {
        public static char[] PunctiationSigns = (" .,?!—-;:\n").ToCharArray();

        public static string[] GetAdaptedPages(IDictionary<string, string> translator,
            string text, int wordsPerPage)
        {
            var words = text.Split(PunctiationSigns, StringSplitOptions.RemoveEmptyEntries);

            string Translate(string word) => translator[word.ToLowerInvariant()].ToUpperInvariant();

            return words
                .Select((x, i) => (Word: x, Index: i))
                .GroupBy(
                    x => x.Index / wordsPerPage,
                    x => Translate(x.Word),
                    (key, adaptedWords) => string.Join(" ", adaptedWords))
                .ToArray();
        }

        static void Main(string[] args)
        {
            var example = "This dog eats too much vegetables after lunch";

            var translator = new Dictionary<string, string>();
            translator["this"] = "Эта";
            translator["dog"] = "собака";
            translator["eats"] = "ест";
            translator["too"] = "слишком";
            translator["much"] = "много";
            translator["vegetables"] = "овощей";
            translator["after"] = "после";
            translator["lunch"] = "обеда";

            var wordsPerPage = 3;
            var result = GetAdaptedPages(translator, example, wordsPerPage);

            foreach(var line in result)
            {
                Console.WriteLine(line);
            }
        }
    }
}
