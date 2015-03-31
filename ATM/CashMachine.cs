﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private List<Cassette> _moneyCassettes;

        private Money _moneyForWithdraw;
        public States CurrentStates { get; private set; }
        public bool HaveMoneyForWithdrow { get; private set; }
        public Money MoneyForWithdraw
        {
            get
            {
                var result = _moneyForWithdraw;
                HaveMoneyForWithdrow = false;
                _moneyForWithdraw = null;
                return result;
            }
            private set
            {
                _moneyForWithdraw = value;
                HaveMoneyForWithdrow = true;
            }
        }
        public States State
        {
            get; private set;
        }
        public CashMachine(IBanknoteSelector banknoteSelector)
        {
            _banknoteSelector = banknoteSelector;
        }

        private readonly IBanknoteSelector _banknoteSelector;

        public void Withdraw(decimal requestedSum)
        {
            States result;
            List<MutablePair<decimal, int>> combination;


            if (!_banknoteSelector.TrySelect(ConvertCassettes(), requestedSum, out result, out combination))
            {
                CurrentStates = result;
                return;
            }
            EraseMoney(combination);
        }

        public List<MutablePair<decimal, int>> ConvertCassettes()
        {
            return
                _moneyCassettes.Select(item => new MutablePair<decimal, int>(item.Banknote.Nominal, item.Number))
                    .ToList();
        }

        private void EraseMoney(List<MutablePair<decimal, int>> combination)
        {
            MoneyForWithdraw = Money.Parse(combination);
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