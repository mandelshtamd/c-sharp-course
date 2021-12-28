using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesCalculator
{
    public static class FilesCalculator
    {
        public static double resultStorage = 0;
        private static readonly Semaphore sem = new Semaphore(1, 1);

        public static void HandleFiles(object objFilePaths)
        {
            var filePaths = (List<string>)objFilePaths;

            foreach(var path in filePaths)
            {
                HandleFile(path);
            }
        }

        private static void HandleFile(string filePath)
        {
            var (operationNum, data) = ParseFile((string)filePath);
            var ans = Calculate(operationNum, data);
            sem.WaitOne();
            resultStorage += ans;
            sem.Release();
        }

        private static Tuple<int, List<double>> ParseFile(string filePath)
        {
            using (FileStream fstream = new FileStream(filePath, FileMode.Open))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                var parsedText = textFromFile.Split("\n");
                var operationNum = int.Parse(parsedText[0]);
                var dataList = new List<string>(parsedText[1].Split(" ")).ConvertAll(s => double.Parse(s));
                return new Tuple<int, List<double>>(operationNum, dataList);
            }
        }

        private static double Calculate(int operationNum, List<double> nums)
        {
            if (operationNum == 1)
            {
                return nums.Aggregate((sum, i) => sum + i);
            } 
            else if (operationNum == 2)
            {
                return nums.Aggregate((prod, i) => prod * i);
            } 
            else
            {
                return nums.Aggregate((sum, i) => sum + i * i);
            }
        }
    }
}
