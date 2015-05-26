namespace ATM.Viewers
{
    public interface IMoneyViewer
    {
        string ToString(Money money, AtmState state);
    }
}
