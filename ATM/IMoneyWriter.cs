namespace ATM
{
    interface IMoneyWriter
    {
        string ToString(Money money, AtmState state);
    }
}
