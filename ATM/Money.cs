using System.Collections.Generic;

namespace ATM
{
    public class Money
    {
        public List<MutablePair<Banknote, int>> Banknotes
        {
            get; private set;
        }

        public States Result
        {
            get; set;
        }

        public Money()
        {
            Banknotes = new List<MutablePair<Banknote, int>>();
        }
    }
}