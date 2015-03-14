namespace ATM
{
    public class Banknote
    {
        public int Nominal
        {
            get; set;
        }

        public Banknote(int nominal)
        {
            Nominal = nominal;
        }
    }
}