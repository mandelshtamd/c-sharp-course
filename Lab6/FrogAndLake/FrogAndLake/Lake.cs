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
            _stones = new List<int>(new int[stones.Count]);
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
