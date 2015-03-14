namespace ATM
{
    public class MutablePair<TKey, TValue>
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
    }
}
