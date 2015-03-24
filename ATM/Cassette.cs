namespace ATM
{
    public class Cassette
    {
        public int Number { get; set; }
        public Banknote Banknote { get; private set; }
        public decimal TotalSum
        {
            get { return Banknote.Nominal * Number; }
            
        }

        public Cassette(Banknote banknote, int number)
        {
            Number = number;
            Banknote = banknote;
        }
    }
}
