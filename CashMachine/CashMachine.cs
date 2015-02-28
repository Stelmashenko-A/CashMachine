using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace CashMachine
{
    internal class CashMachine
    {
        public CashMachine()
        {
            TotalAmountOfMoney = 0;
            NumberOfPars = 0;
            string data;
            using (StreamReader sr = new StreamReader("Money.txt"))
            {
                data = sr.ReadLine();
            }
            string[] strArray = data.Split(' ');
            Container = new Dictionary<int, int>();
            NumberOfPars = strArray.Length/2;
            for (int i = 0; i < NumberOfPars; i++)
            {
                int par = int.Parse(strArray[i*2]);
                int num = int.Parse(strArray[i*2 + 1]);
                TotalAmountOfMoney += par*num;
                Container.Add(par, num);
            }
        }

        private Dictionary<int, int> Container { get; set; }

        private int TotalAmountOfMoney;

        private int NumberOfPars { get; set; }

        public CashBack GetMoney(int Amount)
        {
            CashBack cashBack = new CashBack(Container.Keys.ToList());
            if (TotalAmountOfMoney == 0)
            {
                cashBack.Result = States.IsEmpty;
                return cashBack;
            }
            if (Amount > TotalAmountOfMoney)
            {
                cashBack.Result = States.MoneyDeficiency;
                return cashBack;
            }
            GenerateCashBack(Amount, cashBack, 0, 0);
            foreach (var variable in cashBack.Value.Keys)
            {
                Container[variable] -= cashBack.Value[variable];
            }
            return cashBack;
        }

        private void GenerateCashBack(int Amount, CashBack cashBack, int RecursionLevel, int BankNotes)
        {

            int CurrentParPosition = RecursionLevel;
            int CurrentPar = Container.Keys.ElementAt(CurrentParPosition);

            int Remainder = Amount%CurrentPar;
            if (Amount/CurrentPar > Container[CurrentPar])
            {
                Remainder = Amount - Container[CurrentPar]*CurrentPar;
            }
            if (RecursionLevel == NumberOfPars - 1 && BankNotes == 0 &&
                ((Amount%CurrentPar) != 0 || ((Amount/CurrentPar) > Container[CurrentPar])))
            {
                cashBack.Result = States.AllCombinationsFailed;
                return;
            }

            cashBack.Value[CurrentPar] = Math.Min(Amount/CurrentPar, Container[CurrentPar]);
            BankNotes += cashBack.Value[CurrentPar];
            if (Remainder == 0)
            {
                cashBack.Result = States.OK;
                return;
            }
            RecursionLevel++;
            cashBack.Result = States.CombinationFailed;
            if (RecursionLevel < NumberOfPars)
            {
                cashBack.Result = States.NULL;
                while (cashBack.Result != States.OK && cashBack.Result != States.AllCombinationsFailed)
                {
                    GenerateCashBack(Remainder, cashBack, RecursionLevel, BankNotes);
                    if (cashBack.Result == States.CombinationFailed)
                    {
                        if (cashBack.Value[CurrentPar] > 0)
                        {
                            cashBack.Value[CurrentPar]--;
                            BankNotes--;
                            Remainder += CurrentPar;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }

            return;
        }
    }
}
