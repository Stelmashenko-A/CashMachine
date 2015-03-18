using System.Globalization;

namespace ATM
{
    public class Banknote
    {
        public decimal Nominal
        {
            get; set;
        }

        public Banknote(decimal nominal)
        {
            Nominal = nominal;
        }

        public override string ToString()
        {
            return Nominal.ToString(CultureInfo.InvariantCulture);
        }
    }
}