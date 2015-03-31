namespace ATM
{
    public class Cassette
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

        public void Erase(int number)
        {
            Number -= number;
        }

    }
}
