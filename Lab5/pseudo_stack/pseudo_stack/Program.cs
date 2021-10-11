using System;

namespace pseudo_stack
{
    class Program
    {
        static void Main(string[] args)
        {
            var elems = new int[]{ 1, 2, 5, 8, -9, 0 };
            var testStack = new PseudoStack<int>(elems);
            Console.Write($"Our stack values are: ");
            
            foreach(var e in elems)
            {
                Console.Write(e + " ");
            }

            Console.WriteLine("");


            Console.WriteLine($"stack size = {testStack.Count}");
            Console.Write("After pop: ");
            for (int i = 0; i < elems.Length - 1; i++)
            {
                Console.Write(testStack.Pop() + ", ");
            }
            Console.WriteLine(testStack.Pop());
        }
    }
}
