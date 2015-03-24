using System.Collections.Generic;

namespace ATM
{
    public class CashMachine
    {
        private readonly List<Cassette> _moneyCassettes;
        public CashMachine(List<Cassette> moneyCassettes, IBanknoteSelector banknoteSelector)
        {
            _banknoteSelector = banknoteSelector;
            _moneyCassettes = moneyCassettes;
        }

        private readonly IBanknoteSelector _banknoteSelector;

        public Money Withdraw(decimal requestedSum)
        {
            _banknoteSelector.Initialize(_moneyCassettes);
            _banknoteSelector.TrySelect(requestedSum);
            return _banknoteSelector.SelectedMoney;
        }
    }
}