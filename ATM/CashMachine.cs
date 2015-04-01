using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private List<Cassette> _moneyCassettes;

        private Money _moneyForWithdraw;
        public AtmState CurrentState { get; private set; }
        public bool HaveMoneyForWithdrow { get; private set; }
        private Money PreparedMoney
        {
            get
            {
                var result = _moneyForWithdraw;
                HaveMoneyForWithdrow = false;
                _moneyForWithdraw = null;
                return result;
            }
            set
            {
                _moneyForWithdraw = value;
                HaveMoneyForWithdrow = true;
            }
        }

        public CashMachine(IBanknoteSelector banknoteSelector)
        {
            _banknoteSelector = banknoteSelector;
        }

        private readonly IBanknoteSelector _banknoteSelector;

        public Money Withdraw(decimal requestedSum)
        {
            AtmState result;
            List<MutablePair<decimal, int>> combination;

            if (!_banknoteSelector.TrySelect(ConvertCassettes(), requestedSum, out result, out combination))
            {
                CurrentState = result;
                return new Money();
            }
            RemoveMoney(combination);
            return PreparedMoney;
        }

        public List<MutablePair<decimal, int>> ConvertCassettes()
        {
            return
                _moneyCassettes.Select(item => new MutablePair<decimal, int>(item.Banknote.Nominal, item.Number))
                    .ToList();
        }

        private void RemoveMoney(List<MutablePair<decimal, int>> combination)
        {
            PreparedMoney = Money.Parse(combination);
            foreach (var variable in _moneyForWithdraw.Banknotes)
            {
                var variableTmp = variable;
                foreach (var item in _moneyCassettes.Where(item => item.Banknote.Nominal == variableTmp.Key.Nominal))
                {
                    item.Erase(variable.Value);
                }
            }
        }

        public void InserCassettes(List<Cassette> cassetes)
        {
            _moneyCassettes = cassetes;
        }
    }
}