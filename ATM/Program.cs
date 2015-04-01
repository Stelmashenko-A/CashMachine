using System;
using System.Collections.Generic;

namespace ATM
{
    class Program
    {
        private const string Path = "Money.txt";

        private static readonly Dictionary<AtmState, string> ErrromMessage = new Dictionary<AtmState, string>
        {
            {AtmState.CombinationFailed, "Enter other sum"},
            {AtmState.MoneyDeficiency, "Insufficient money"}
        };

        static void Main()
        {
            var moneyCassettes = CassetteReader.ReadCassette(Path);
            var atm = new CashMachine(new GreedyAlgorithm());
            atm.InserCassettes(moneyCassettes);
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

                var money = atm.Withdraw(requestedSum);

                if (money.TotalSum!=0)
                {
                    Console.WriteLine(money);
                    continue;
                }

                Console.WriteLine(ErrromMessage[atm.CurrentState]);
            }
        }
    }
}
