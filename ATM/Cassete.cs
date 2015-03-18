namespace ATM
{
    public class Cassete
    {
        public Money MoneyInCassete
        {
            get; set;
        }

        public Cassete()
        {
            MoneyInCassete = new Money();
        }
    }
}
