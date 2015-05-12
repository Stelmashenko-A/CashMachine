namespace ATM.Output
{
    public interface IMoneyViewer
    {
        string ToString(Money money, AtmState state);
    }
}
