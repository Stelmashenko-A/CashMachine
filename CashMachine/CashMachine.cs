using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    class CashMachine
    {
        Dictionary<int, int> Container { get; set; }
        int NumberOfPars { get; set; }

        public CashBack GetMoney(int Amount)
        {
            CashBack delivery = new CashBack();
            return delivery;
        }
        States GetMoney(int Amount, CashBack cashBack, int RecursionLevel, int BankNotes)
        {
            
            int CurrentParPosition = Container.Keys.Count()-1;
            int CurrentPar = Container.Keys.ElementAt(CurrentParPosition);
            int Remainder = Amount % CurrentPar;
            if (BankNotes == 0 && Amount % CurrentPar != 0)
            {
                return States.AllCombinationsFailed;
            }
            if (Remainder == 0) return States.OK;
            cashBack.Value[CurrentPar] = Amount / CurrentPar;
            BankNotes += Amount / CurrentPar;
            RecursionLevel++;
            States result = States.CombinationFailed;
            if (RecursionLevel < NumberOfPars)
            {
                result = States.NULL;
                while (result != States.OK || result != States.AllCombinationsFailed);
                {
                    result = GetMoney(Remainder, cashBack, RecursionLevel, BankNotes);
                    if(result == States.CombinationFailed)
                    {
                        if (cashBack.Value[CurrentPar] > 0)
                        {
                            cashBack.Value[CurrentPar]--;
                            BankNotes--;
                            Amount += CurrentPar;
                        }
                        else
                        {
                            return result;
                        }
                    }
                } 
            }
            
            return result;
        }
        
    }
}
