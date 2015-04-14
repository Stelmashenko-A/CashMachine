using System;

namespace ATM
{
    public class Cassette:ICloneable
    {
        public int Number
        {
            get; private set;
        }

        public Banknote Banknote
        {
            get; private set;
        }

        public decimal TotalSum
        {
            get { return Banknote.Nominal * Number; }   
        }
        
        public Cassette(Banknote banknote, int number)
        {
            Number = number;
            Banknote = banknote;
        }

        public void RemoveBanknotes(int banknotesCount)
        {
            Number -= banknotesCount;
        }

        public object Clone()
        {
            return new Cassette((Banknote) Banknote.Clone(), Number);
        }
    }
}
