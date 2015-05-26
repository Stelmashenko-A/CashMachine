using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ATM
{
    [Serializable]
    [DataContract]
    public class Banknote : ICloneable
    {
        public Banknote() { }

        [DataMember]
        public decimal Nominal
        {
            get; private set;
        }

        public Banknote(decimal nominal)
        {
            Nominal = nominal;
        }

        public override string ToString()
        {
            return Nominal.ToString(CultureInfo.InvariantCulture);
        }

        public object Clone()
        {
            return new Banknote(Nominal);
        }
    }
}