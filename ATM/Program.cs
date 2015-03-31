using System;

namespace ATM
{
    class Program
    {
        private const string Path = "Money.txt";

        static void Main()
        {
            var moneyCassettes = CassetteReader.ReadCassette(Path);
            var atm = new CashMachine(moneyCassettes, new GreedyAlgorithm());
            Console.WriteLine("For finishing input \"exit\"");
            while (true)
            {
                var input = Console.ReadLine();
                if(input == "exit")break;
                int requestedSum;
                if (!int.TryParse(input, out requestedSum))
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }
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
