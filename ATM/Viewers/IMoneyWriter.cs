namespace ATM.Viewers
{
    interface IMoneyWriter
    {
        string ToString(Money money, AtmState state);
    }
}
