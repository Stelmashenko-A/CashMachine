namespace ATM
{
    public class Cassete
    {
        public Money Money
        {
            get; set;
        }

        public Cassete()
        {
            Money = new Money();
        }
    }
}
