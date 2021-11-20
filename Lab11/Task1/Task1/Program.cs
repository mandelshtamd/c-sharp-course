using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class Program
    {
        public static void WriteRandomNumsToFile()
        {
            var rand = new Random();
            var randList = Enumerable.Range(0, 100000000).OrderBy(x => rand.Next());

            // change path
            var path = "C:\\Users\\Owner\\source\\repos\\C# course\\Lab11\\Task1\\Task1\\random.txt";
            using (FileStream fs = File.Create(path))
            using (TextWriter writer = new StreamWriter(fs))
            {
                foreach(var randNum in randList)
                {
                    var formatedNum = string.Format("{0:d9}", randNum);
                    writer.WriteLine(formatedNum);
                }
            }
        }

        static void Main(string[] args)
        {
            WriteRandomNumsToFile();
        }
    }
}
