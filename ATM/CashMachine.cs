using System;
using System.Collections.Generic;
using System.IO;
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
            string data;
            using (var sr = new StreamReader("Money.txt"))
            {
                data = sr.ReadLine();
            }
            if (data == null) return;
            var strArray = data.Split(' ');
            var numberOfPars = strArray.Length / 2;
            for (var i = 0; i < numberOfPars; i++)
            {
                var nominal = int.Parse(strArray[i * 2]);
                var num = int.Parse(strArray[i * 2 + 1]);
                _container.Banknotes.Add(new MutablePair<Banknote, int>(new Banknote(nominal), num));
            }
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
            foreach (var variable in moneyStack)
            {
                money.Banknotes.Add(variable);
            }
            return money;
        }
    }
}