using System;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    public class CashMachine
    {
        private readonly Money _container;

        private int TotalSum
        {
            get
            {
                return _container.Banknotes.Sum(item => item.Value*item.Key.Nominal);
            }
        }

        public CashMachine()
        {
            _container = new Money();
            _container.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(200), 100));
            _container.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(100), 0));
            _container.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(50), 100));
            _container.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(20), 100));
        }

        public Money Withdraw(int requestedSum)
        {
            var money = new Money();
            if (TotalSum < requestedSum)
            {
                money.Result = States.MoneyDeficiency;
                return money;
            }

            var nominalUsed = new Stack<MutablePair<Banknote, int>>();
            var nominalForUsing = new LinkedList<MutablePair<Banknote, int>>();
            var moneyStack = new Stack<MutablePair<Banknote, int>>();
            foreach (var item in _container.Banknotes)
            {
                nominalForUsing.AddFirst(item);
            }

            while (requestedSum > 0)
            {
                var currenBanknotes = nominalForUsing.Last();
                if (nominalForUsing.Count() > 1 ||
                    (requestedSum%currenBanknotes.Key.Nominal == 0 &&
                     requestedSum%currenBanknotes.Key.Nominal <= currenBanknotes.Value))
                {
                    nominalForUsing.RemoveLast();
                    var banknotesNumber = Math.Min(requestedSum/currenBanknotes.Key.Nominal,
                        currenBanknotes.Value);
                    currenBanknotes.Value -= banknotesNumber;
                    requestedSum -= currenBanknotes.Key.Nominal*banknotesNumber;
                    nominalUsed.Push(currenBanknotes);
                    moneyStack.Push(new MutablePair<Banknote, int>(currenBanknotes.Key, banknotesNumber));
                    continue;
                }
                while (nominalUsed.Any() && moneyStack.Peek().Value == 0)
                {
                    nominalForUsing.AddLast(nominalUsed.Pop());
                    moneyStack.Pop();
                }
                if (!moneyStack.Any())
                {
                    money.Result = States.CombinationFailed;
                    return money;
                }
                moneyStack.Peek().Value--;
                nominalUsed.Peek().Value++;
                requestedSum += nominalUsed.Peek().Key.Nominal;
            }
            money.Result = States.Success;
            return money;
        }
    }
}