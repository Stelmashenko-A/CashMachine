﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CashMachine
{
    class CashMachine
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
            for(int i = 0; i < NumberOfPars; i++)
            {
                int par = int.Parse(strArray[i * 2]);
                int num = int.Parse(strArray[i * 2 + 1]);
                TotalAmountOfMoney += par * num;
                Container.Add(par, num);
            }
        }
        Dictionary<int, int> Container { get; set; }
        int TotalAmountOfMoney;

        int NumberOfPars { get; set; }

        public CashBack GetMoney(int Amount)
        {
            CashBack cashBack = new CashBack(Container.Keys.ToList());
            GenerateCashBack(Amount, cashBack, 0, 0);
            return cashBack;
        }

        
        States GenerateCashBack(int Amount, CashBack cashBack, int RecursionLevel, int BankNotes)
        {

            int CurrentParPosition = RecursionLevel;
            int CurrentPar = Container.Keys.ElementAt(CurrentParPosition);
            int Remainder = Amount % CurrentPar;
            if (BankNotes == 0 && Amount % CurrentPar != 0 && RecursionLevel == NumberOfPars-1)
            {
                return States.AllCombinationsFailed;
            }

            cashBack.Value[CurrentPar] = Amount / CurrentPar;
            BankNotes += Amount / CurrentPar;
            if (Remainder == 0)
            {

                return States.OK;
            }
            RecursionLevel++;
            cashBack.Result = States.CombinationFailed;
            if (RecursionLevel < NumberOfPars)
            {
                cashBack.Result = States.NULL;
                while (cashBack.Result != States.OK && cashBack.Result != States.AllCombinationsFailed)
                {
                    cashBack.Result = GenerateCashBack(Remainder, cashBack, RecursionLevel, BankNotes);
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
                            return cashBack.Result;
                        }
                    }
                }
            }

            return cashBack.Result;
        }
    }
}