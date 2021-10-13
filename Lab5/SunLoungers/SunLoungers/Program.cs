using System;
using System.Reflection.Metadata.Ecma335;

namespace SunLoungers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Some examples from task statement:");
            Console.WriteLine($"SunLoungers(\"10001\") -> {Solution.SunLoungers("10001")}");
            Console.WriteLine($"SunLoungers(\"00101\") -> {Solution.SunLoungers("00101")}");
            Console.WriteLine($"SunLoungers(\"0\") -> {Solution.SunLoungers("0")}");
            Console.WriteLine($"SunLoungers(\"000\") -> {Solution.SunLoungers("000")}");
        }
    }
}
