using System;

namespace customLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new LinkedList<int>(8);
            list.Push(3);

            foreach (Node<int> node in list)
            {
                Console.WriteLine($"node {node.Value}");
            }
        }
    }
}
