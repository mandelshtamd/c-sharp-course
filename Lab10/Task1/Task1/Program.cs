using System;
using System.Reflection;

namespace Task1
{
    class Program
    {

        static void Main(string[] args)
        {
            string inputOperation = Console.ReadLine();
            var box = Activator.CreateInstance(typeof(BlackBox), true);

            while (inputOperation != "")
            {
                try
                {
                    var methodInfo = new MethodHandler(inputOperation);

                    box.GetType()
                    .GetMethod(methodInfo.info.MethodName, BindingFlags.NonPublic | BindingFlags.Instance)
                    .Invoke(box, methodInfo.info.MethodArguments);

                    Console.WriteLine($"=> {box.GetType().GetTypeInfo().GetDeclaredField("innerValue").GetValue(box)}");
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }

                inputOperation = Console.ReadLine();
            }
        }
    }
}