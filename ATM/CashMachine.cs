using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace ATM
{
    public class CashMachine
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));

        private readonly List<Cassette> _moneyCassettes = new List<Cassette>();

        readonly LogViewer _logViewer = new LogViewer();

        private Money _moneyForWithdraw;

        public AtmState CurrentState { get; private set; }

        public bool HaveMoneyForWithdraw { get; private set; }

        private readonly IBanknoteSelector _banknoteSelector;

        private Money PreparedMoney
        {
            get
            {
                var result = (Money)_moneyForWithdraw.Clone();
                HaveMoneyForWithdraw = false;
                _moneyForWithdraw = null;
                return result;
            }
            set
            {
                _moneyForWithdraw = value;
                HaveMoneyForWithdraw = true;
            }
        }

        public CashMachine(IBanknoteSelector banknoteSelector)
        {
            _banknoteSelector = banknoteSelector;
        }

        public Money Withdraw(decimal requestedSum)
        {
            AtmState result;
            List<MutablePair<decimal, int>> combination;
            var moneyForWithdraw = new Money();

            if (_banknoteSelector.TrySelect(ConvertCassettes(), requestedSum, out result, out combination))
            {
                UpdateCassettes(combination);
                moneyForWithdraw = (Money)PreparedMoney.Clone();
            }
            CurrentState = result;
            Log.Info(_logViewer.ToString(moneyForWithdraw,result));
            return moneyForWithdraw;
        }

        public List<MutablePair<decimal, int>> ConvertCassettes()
        {
            CurrentState = AtmState.NoError;
            return
                _moneyCassettes.Select(item => new MutablePair<decimal, int>(item.Banknote.Nominal, item.Number))
                    .ToList();
        }

        private void UpdateCassettes(List<MutablePair<decimal, int>> combination)
        {
            try
            {
                if (combination == null)
                {
                    throw new ArgumentNullException("combination");
                }
                Money money;
                if (!Money.TryParse(combination, out money))
                {
                    throw new FormatException("combination");
                }
                PreparedMoney = money;
                foreach (var variable in _moneyForWithdraw.Banknotes)
                {
                    var variableTmp = variable;
                    foreach (var item in _moneyCassettes.Where(item => item.Banknote.Nominal == variableTmp.Key.Nominal)
                        )
                    {
                        item.RemoveBanknotes(variable.Value);
                    }
                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
            }
            catch (FormatException ex)
            {
                Log.Error("Can't parse combination from algoritm (combintion can be equal null)", ex);
            }

        }

        public void InsertCassettes(List<Cassette> cassetes)
        {
            try
            {
                if (cassetes == null)
                {
                    throw new ArgumentNullException("cassetes");
                }
                foreach (var variable in cassetes)
                {
                    _moneyCassettes.Add((Cassette) variable.Clone());
                }
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
            }
        }
    }
}