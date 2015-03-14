using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace CashMachine
{
    internal class CashMachine
    {
        public CashMachine()
        {
            _totalAmountOfMoney = 0;
            NumberOfPars = 0;
            string data;
            using (var sr = new StreamReader("Money.txt"))
            {
                data = sr.ReadLine();
            }
            var strArray = data.Split(' ');
            Container = new Dictionary<int, int>();
            NumberOfPars = strArray.Length/2;
            for (var i = 0; i < NumberOfPars; i++)
            {
                var par = int.Parse(strArray[i*2]);
                var num = int.Parse(strArray[i*2 + 1]);
                _totalAmountOfMoney += par*num;
                Container.Add(par, num);
            }
        }

        private Dictionary<int, int> Container { get; set; }

        private int _totalAmountOfMoney;

        private int NumberOfPars { get; set; }

        public CashBack GetMoney(int amount)
        {
            var cashBack = new CashBack(Container.Keys.ToList());
            if (_totalAmountOfMoney == 0)
            {
                cashBack.Result = States.IsEmpty;
                return cashBack;
            }
            if (amount > _totalAmountOfMoney)
            {
                cashBack.Result = States.MoneyDeficiency;
                return cashBack;
            }
            GenerateCashBack(amount, cashBack, 0, 0);
            if (cashBack.Result == States.Ok)
            {
                foreach (var variable in cashBack.Value.Keys)
                {
                    Container[variable] -= cashBack.Value[variable];
                }
                _totalAmountOfMoney -= amount;
            }
            return cashBack;
        }

        private void GenerateCashBack(int amount, CashBack cashBack, int recursionLevel, int bankNotes)
        {

            var currentParPosition = recursionLevel;
            var currentPar = Container.Keys.ElementAt(currentParPosition);

            var remainder = amount%currentPar;
            if (amount/currentPar > Container[currentPar])
            {
                remainder = amount - Container[currentPar]*currentPar;
            }
            if (recursionLevel == NumberOfPars - 1 && bankNotes == 0 &&
                ((amount%currentPar) != 0 || ((amount/currentPar) > Container[currentPar])))
            {
                cashBack.Result = States.AllCombinationsFailed;
                return;
            }

            cashBack.Value[currentPar] = Math.Min(amount/currentPar, Container[currentPar]);
            bankNotes += cashBack.Value[currentPar];
            if (remainder == 0)
            {
                cashBack.Result = States.Ok;
                return;
            }
            recursionLevel++;
            cashBack.Result = States.CombinationFailed;
            if (recursionLevel >= NumberOfPars) return;
            cashBack.Result = States.Null;
            while (cashBack.Result != States.Ok && cashBack.Result != States.AllCombinationsFailed)
            {
                GenerateCashBack(remainder, cashBack, recursionLevel, bankNotes);
                if (cashBack.Result != States.CombinationFailed) continue;
                if (cashBack.Value[currentPar] > 0)
                {
                    cashBack.Value[currentPar]--;
                    bankNotes--;
                    remainder += currentPar;
                }
                else
                {
                    return;
                }
            }
        }
    }
}
