using System;
using System.Collections.Generic;

namespace Stack
{
    public class Stack<T> where T : IComparable<T>, new()
    {
        private readonly List<T> _elementsList = new List<T>();
        // contains historical order of minValues to speed up MinValue operation.
        private readonly List<T> _minValues = new List<T>();

        public void Push(T value)
        {
            _elementsList.Add(value);
            // if minValues list is empty or value <= last element in minValues
            if (_minValues.Count == 0 || _minValues[^1].CompareTo(value) >= 0)
            {
                _minValues.Add(value);
            }
        }

        public T Pop()
        {
            var lastElement = _elementsList[^1];
            if (lastElement.CompareTo(_minValues[^1]) >= 0)
            {
                _minValues.RemoveAt(_minValues.Count - 1);
            }
            _elementsList.RemoveAt(_minValues.Count - 1);

            return lastElement;
        }

        // will return default value if minValues list is empty yet.
        public T MinValue()
        {
            if (_minValues.Count == 0)
            {
                return new T();
            }

            return _minValues[^1];
        }
    }
}
