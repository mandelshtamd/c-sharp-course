using System;
using System.Threading.Tasks;

namespace MatrixMultiplication
{
    class Program
    {
        private static double[,] MultiplyMatrix(double[,] matrixFirst, double[,] matrixSecond)
        {
            var resultRows = matrixFirst.GetLength(0);
            int resultColumns = matrixSecond.GetLength(1);
            double[,] result = new double[resultRows, resultColumns];
            Parallel.For(0, resultRows, (i) =>                                      
            {
                Parallel.For(0, resultColumns, j =>
                {
                    result[i, j] = 0.0;
                    for (long k = 0; k < matrixFirst.GetLength(1); ++k)
                    {
                        result[i, j] += matrixFirst[i, k] * matrixSecond[k, j];
                    }
                    });
             });
            return result;
        }

        private static void PrintMatrix(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            const int size = 3;

            double[,] matrixFirst = new double[size, size];
            double[,] matrixSecond = new double[size, size];
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrixFirst[i, j] = r.Next(100);
                    matrixSecond[i, j] = r.Next(100);
                }
            }
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrixFirst);
            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrixSecond);
            var res = MultiplyMatrix(matrixFirst, matrixSecond);
            Console.WriteLine("Получившийся результат:");
            PrintMatrix(res);
        }
    }
}
