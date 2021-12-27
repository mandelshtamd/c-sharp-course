using System;
using System.Collections;
using System.Linq;
using System.Threading;

namespace OutputToList
{
    class Program
    {
        private static Random randomizer = new Random();
        private static ArrayList sortedList = new ArrayList();

        static string GenerateRandomString(int size)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, size)
                .Select(s => s[randomizer.Next(s.Length)]).ToArray());
        }

        static string[] GenerateRandomStrings(int num)
        {
            var output = new string[num];

            var maxStringLength = 40;

            for (int i = 0; i < num; i++)
            {
                var randomStringSize = randomizer.Next(maxStringLength);
                output[i] = GenerateRandomString(randomStringSize);
            }
            return output;
        }

        static void Sorter(object str)
        {
            var strSize = ((string)str).Length;
            Thread.Sleep(strSize * 500);
            lock (sortedList.SyncRoot)
            {
                sortedList.Add((string)str);
            }
        }

        static void Main(string[] args)
        {
            var inputSize = randomizer.Next(100);
            Console.WriteLine($"Количество строк: {inputSize}");
            var strings = GenerateRandomStrings(inputSize);

            Thread[] threadsArray = new Thread[inputSize];

            for (int i = 0; i < inputSize; i++)
            {
                threadsArray[i] = new Thread(Sorter);
            }

            for (int i = 0; i < inputSize; i++)
            {
                threadsArray[i].Start(strings[i]);
            }

            for (int i = 0; i < inputSize; i++)
            {
                threadsArray[i].Join();
            }
            
            foreach(var elem in sortedList)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
