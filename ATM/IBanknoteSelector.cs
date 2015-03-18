namespace ATM
{
    public interface IBanknoteSelector
    {
        void Initialize(Cassete cassete);

        void TrySelect(decimal sum);

        Money SelectedMoney { get; }
    }
}
