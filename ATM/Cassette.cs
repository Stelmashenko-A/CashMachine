using System;
using System.Runtime.Serialization;

namespace ATM
{
    [DataContract]
    public class Cassette:ICloneable
    {
        public Cassette()
        { }

        [DataMember]
        public int Number
        {
            get; private set;
        }

        [DataMember]
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
