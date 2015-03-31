using System;

namespace ATM
{
    class Program
    {
        private const string Path = "Money.txt";

        static void Main()
        {
            int requestedSum;
            var moneyCassettes = CassetteReader.ReadCassette(Path);
            var atm = new CashMachine(moneyCassettes, new GreedyAlgorithm());
            while (int.TryParse(Console.ReadLine(), out requestedSum))
            {
                atm.Withdraw(requestedSum);
                if (atm.CurrentStates == AtmStates.HaveMoneyForWithdrow)
                {
                    Console.WriteLine(atm.MoneyForWithdraw);
                }
            }
            CassetteWriter.Write(atm.MoneyCassettes, Path);
        }
    }
}
