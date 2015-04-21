using System;

namespace ATM
{
    public class MutablePair<TKey, TValue>:ICloneable
    {
        public TKey Key
        {
            get; private set;
        }

        public TValue Value
        {
            get; set;
        }

        public MutablePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public object Clone()
        {
            return new MutablePair<TKey, TValue>(Key, Value);
        }
    }
}
