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
            var fileContent = File.ReadLines(filePath);

            var operationNum = int.Parse(fileContent.First());
            var dataList = new List<string>(fileContent.Last().Split(" ")).ConvertAll(s => double.Parse(s));
            return new Tuple<int, List<double>>(operationNum, dataList);
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
                double result = 0;
                foreach(var num in nums)
                {
                    result += num * num;
                }
                return result;
            }
        }
    }
}
