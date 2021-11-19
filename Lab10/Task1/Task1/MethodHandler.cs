using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1
{
    class MethodHandler
    {
        // лучше стараться не использовать публичные поля, а вместе них заводить свойства / property
        // все публичные члены должны нанинаться с заглавной буквы
        public MethodInfo info;
        public MethodHandler(string input)
        {
            var leftBracketIndex = input.IndexOf("(");
            var methodName = input.Substring(0, leftBracketIndex);
            var arguments = input.Substring(leftBracketIndex + 1, input.Length - leftBracketIndex - 2).Split(',').Select(n => (object)Convert.ToInt32(n)).ToArray();
            info = new MethodInfo(methodName, arguments);
        }
        
        public class MethodInfo
        {
            public string MethodName;
            public object[] MethodArguments;

            public MethodInfo(string name, object[] args)
            {
                MethodName = name;
                MethodArguments = args;
            }
        }
    }
}
