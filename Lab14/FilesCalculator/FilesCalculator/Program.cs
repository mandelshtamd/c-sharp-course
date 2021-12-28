using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace FilesCalculator
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Введите число потоков: ");
            var threadsNum = int.Parse(Console.ReadLine());
            var testDirectory = Path.GetFullPath(@"..\..\..\") + "testDirectory";

            var files = Directory.GetFiles(testDirectory);

            threadsNum = Math.Min(files.Length, threadsNum);
            Thread[] threadsArray = new Thread[threadsNum];

            var filesPerThread = (files.Length + threadsNum - 1) / threadsNum;

            var threadLists = new List<List<string>>(threadsNum);
            for (int i = 0; i < threadsNum; i++)
            {
                threadLists[i] = new List<string>();
            }

            for (int i = 0; i < files.Length; i++)
            {
                threadLists[i / filesPerThread].Add(files[i]);
            }

            for (int i = 0; i < threadsNum; i++)
            {
                threadsArray[i] = new Thread(() => FilesCalculator.HandleFiles(threadLists[i]));
                threadsArray[i].Start();
            }

            for (int i = 0; i < threadsNum; i++)
            {
                threadsArray[i].Join();
            }
            Console.WriteLine($"Получившийся результат: {FilesCalculator.resultStorage}");
        }
    }
}
