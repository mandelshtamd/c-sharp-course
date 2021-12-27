using System;
using System.Collections.Generic;
using System.Text;

namespace pseudo_stack
{
    public class PseudoStack<T>
    {
	// старайте размещать в классе сначала все закрытые поля, а потом открытые свойства.
	// открытые поля лучше вообще избегать

        private readonly List<Stack<T>> _listOfStacks = new List<Stack<T>>();
        private readonly int _maxStackSize = 3;

        private int CurrIndex => _listOfStacks.Count - 1;

        public int Count => _maxStackSize * (_listOfStacks.Count - 1) + _listOfStacks[CurrIndex].Count;

        public PseudoStack(params T[] elems)
        {
            foreach (var e in elems)
            {
                this.Push(e);
            }
        }

        public void Push(T e)
        {
            if (_listOfStacks.Count == 0 || _listOfStacks[CurrIndex].Count + 1 > _maxStackSize)
            {
                _listOfStacks.Add(new Stack<T>());
            }
            _listOfStacks[CurrIndex].Push(e);
        }

        public T Pop()
        {
            var elemToReturn = _listOfStacks[CurrIndex].Pop();
            if (_listOfStacks[CurrIndex].Count == 0 && CurrIndex > 0)
            {
                _listOfStacks.RemoveAt(CurrIndex);
            }

            return elemToReturn;
        }
    }
}
