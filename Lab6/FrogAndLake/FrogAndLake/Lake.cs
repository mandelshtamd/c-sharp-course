using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FrogAndLake
{
    class Lake : IEnumerable
    {
        private readonly List<int> _stones;

        public Lake(List<int> stones)
        {
// что-то неестественное вы тут делаете с листом.
// у List есть конструктор, который принимает параметр, определяющий первоначальный размер коллекции.
// вы создаете пустой массив, который потом будет копироваться во внутренний массив листа. Вот часть реализации конструктора:
/*
public List(IEnumerable<T> collection) {
	...
            ICollection<T> c = collection as ICollection<T>;
            if( c != null) {
                int count = c.Count;
                if (count == 0)
                {
                    _items = _emptyArray;
                }
                else {
                    _items = new T[count];
                    c.CopyTo(_items, 0);
                    _size = count;
                }
            }    
*/
            _stones = new List<int>(new int[stones.Count]);

	// логика енумератора могла быть сложнее. в данном случае получилось придумать алгоритм (что очень хорошо)
	// обратите внимание, что перечислитель можно было также построить с использованием yield return
            var stonesLastEvenIndex = (stones.Count - 1) % 2 == 0 ? (stones.Count - 1) : (stones.Count - 2);
            var stonesLastOddIndex = stonesLastEvenIndex + 1 == stones.Count ? (stonesLastEvenIndex - 1) : (stonesLastEvenIndex + 1);

            for (var i = 0; i < stones.Count / 2; i++)
            {
                _stones[i] = stones[i * 2];
            }

            for (var i = stones.Count / 2; i < stones.Count; i++)
            {
                _stones[i] = stones[stonesLastOddIndex - (i - stones.Count / 2) * 2];
            }
        }

        public LakeEnum GetEnumerator()
        {
            return new LakeEnum(_stones);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
    }

    public class LakeEnum : IEnumerator
    {
//Стоит сделать это поле закрытым или завести открытое свойство (property). Вообще публичные поля в классе - это плохой стиль
        public List<int> Stones;

        private int _pos = -1;

        public LakeEnum(List<int> stones)
        {
            Stones = stones;
        }

        public bool MoveNext()
        {
            _pos++;
            return (_pos < Stones.Count);
        }

        public void Reset()
        {
            _pos = -1;
        }

        object IEnumerator.Current => Current;

        public int Current
        {
            get
            {
                try
                {
                    return Stones[_pos];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
