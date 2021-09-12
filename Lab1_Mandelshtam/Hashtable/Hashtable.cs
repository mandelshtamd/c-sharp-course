using System;
using System.Collections.Generic;

namespace Hashtable
{
    public class Hashtable<TK, TV>
    {
        private const int Size = 8;
        private readonly LinkedList<KeyValuePair<TK, TV>>[] _items;

        public Hashtable()
        {
            _items = new LinkedList<KeyValuePair<TK, TV>>[Size];
        }

        protected int GetHashCodePosition(TK key)
        {
            var position = Math.Abs(key.GetHashCode() % Size);
            return position;
        }

        public void Add(TK key, TV value)
        {
            var position = GetHashCodePosition(key);
            var linkedList = GetListByPosition(position);
            var item = new KeyValuePair<TK, TV>(key, value);
            linkedList.AddLast(item);
        }

        public void Remove(TK key)
        {
            var position = GetHashCodePosition(key);
            var list = GetListByPosition(position);
            var itemIsFounded = false;
            var foundedItem = default(KeyValuePair<TK, TV>);

            foreach (var item in list)
            {
                if (item.Key.Equals(key))
                {
                    itemIsFounded = true;
                    foundedItem = item;
                }
            }

            if (itemIsFounded)
            {
                list.Remove(foundedItem);
            }
        }

        public TV Find(TK key)
        {
            var position = GetHashCodePosition(key);
            var linkedList = GetListByPosition(position);
            foreach (var item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            throw new KeyNotFoundException();
        }

        private LinkedList<KeyValuePair<TK, TV>> GetListByPosition(int position)
        {
            var list = _items[position];
            // if list already exists we return it
            if (list != null) return list;

            // else we create a new one
            list = new LinkedList<KeyValuePair<TK, TV>>();
            _items[position] = list;

            return list;
        }
    }
}
