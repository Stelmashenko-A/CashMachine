namespace ATM.Output
{
    interface IMoneyWriter
    {
        string ToString(Money money, AtmState state);
    }
}
