using System;
using System.Collections.Generic;
using System.Linq;

namespace Hashtable
{
    public class Hashtable<TK , TV>
    {
        private int _size;
        private int _capacity;
        private Element<TK, TV>[] _items;

        public Hashtable()
        {
            _size = 0;
            _capacity = 4;
            _items = new Element<TK, TV>[_capacity];
        }

        public Hashtable(int capacity)
        {
            _size = 0;
            _capacity = capacity;
            _items = new Element<TK, TV>[_capacity];
        }

        public void Put(TK key, TV value)
        {
            if (_size < _capacity)
            {
                // обычно для того, чтобы оставаться в положительных числах, применяют маску 0x7ffffffff
                int hash = (key.GetHashCode() & 0x7fffffff) % _capacity;
                while (_items[hash] != null)
                {
                    hash++;
                    hash %= _capacity;
                }
                _items[hash] = new Element<TK, TV>(key, value);
                _size++;
            }
            else
            {
                Rehash();
                Put(key, value);
            }
        }

        private void Rehash()
        {
            _capacity *= 2;
            var newElements = new Element<TK,TV>[_capacity];
            var oldElements = _items;
            _items = newElements;
            _size = 0;
            foreach (var elem in oldElements)
            {
                Put(elem.GetKey(), elem.GetValue());
            }
        }

        public void Remove(TK key)
        {
            int hash = Math.Abs(key.GetHashCode() % _capacity);
            for (var i = hash; i < _capacity; i++)
            {
                var testKey = _items[i].GetKey();
                if (testKey.Equals(key))
                {
                    _items[i] = null;
                    _size--;
                    return;
                }
            }

            throw new KeyNotFoundException();
        }

        public TV Get(TK key)
        {
            var hash = Math.Abs(key.GetHashCode() % _capacity);
            for (int i = hash; i < _capacity; i++)
            {
                if (_items[i] != null && _items[i].GetKey().Equals(key))
                {
                    return _items[i].GetValue();
                }
            }

            throw new KeyNotFoundException();
        }

        public int GetCapacity()
        {
            return _capacity;
        }
    }
}