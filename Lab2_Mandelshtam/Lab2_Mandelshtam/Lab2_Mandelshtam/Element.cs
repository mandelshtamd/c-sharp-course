using System;


namespace Hashtable
{
    public class Element<TK, TV>
    {
        private TK _key;
        private TV _value;

        public Element(TK key, TV value)
        {
            _key = key;
            _value = value;
        }

        public TK GetKey()
        {
            return _key;
        }

        public void SetKey(TK key)
        {
            _key = key;
        }

        public TV GetValue()
        {
            return _value;
        }

        public void SetValue(TV value)
        {
            _value = value;
        }
    }
}
