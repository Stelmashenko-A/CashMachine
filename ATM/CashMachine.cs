namespace ATM
{
    public class CashMachine
    {
        private readonly Cassete _container;

        public CashMachine(Cassete cassete, IBanknoteSelector banknoteSelector)
        {
            _container = cassete;
            _banknoteSelector = banknoteSelector;
        }

        private readonly IBanknoteSelector _banknoteSelector;

        public Money Withdraw(decimal requestedSum)
        {
            _banknoteSelector.Initialize(_container);
            _banknoteSelector.TrySelect(requestedSum);
            return _banknoteSelector.SelectedMoney;
        }
    }
}