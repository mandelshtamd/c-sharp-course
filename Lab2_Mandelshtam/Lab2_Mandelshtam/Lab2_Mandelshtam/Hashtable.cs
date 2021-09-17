using System;
using System.Collections.Generic;
using System.Linq;

namespace Hashtable
{
    public class Hashtable<TK , TV> where TK : IComparable
    {
        private int _size;
        private int _capacity;
        private Element<TK, TV>[] _items;

        public Hashtable()
        {
            _size = 0;
            _capacity = 8;
            _items = new Element<TK, TV>[_capacity];
        }

        public Hashtable(int capacity)
        {
            _size = 0;
            _capacity = capacity;
            _items = new Element<TK, TV>[_capacity];
        }

        private void Expand()
        {
            var tempArray = new Element<TK, TV>[_capacity * 2];
            Array.Copy(_items, tempArray, _capacity);
            _items = tempArray;
            _capacity *= 2;
        }

        private int Probe(TK key)
        {
            var hashKey = key.GetHashCode();
            if (_size == _capacity)
            {
                Expand();
            }

            var index = 0;
            for (int i = hashKey;; i++)
            {
                if (_items[(i + index * index) % _capacity] == null)
                {
                    return i;
                }
                index++;
            }
        }

        private int Search(TK key)
        {
            int hashKey = key.GetHashCode();
            int j = _capacity;
            for (int i = hashKey; i < _capacity; i++)
            {
                if (_items[(i + j * j) % _capacity] != null && _items[(i + j * j) % _capacity].GetKey().Equals(key))
                {
                    return (i + j * j) % _capacity;
                }
                j++;
            }

            j = _capacity;
            for (var i = 0; i < hashKey; i++)
            {
                if (_items[(i + j * j) % _capacity] != null && _items[(i + j * j) % _capacity].GetKey().Equals(key))
                {
                    return (i + j * j) % _capacity;
                }
                j++;
            }
            return -1;
        }

        public TV Get(TK key)
        {
            var position = Search(key);
            if (position != -1) 
                return (TV)_items[position].GetValue();
            else 
                return default(TV);
        }

        public TV Put(TK key, TV value)
        {
            _items[Probe(key)] = new Element<TK, TV>(key, value);
            return value;
        }

        public TV Remove(TK key)
        {
            int position = Search(key);
            TV val = default(TV);
            if (position != -1)
            {
                val = _items[position].GetValue();
                _items[position] = null;
            }
            return val;
        }

        public void Clear()
        {
            _capacity = 8;
            _size = 0;
            _items = new Element<TK, TV>[_capacity];
        }
    }
}