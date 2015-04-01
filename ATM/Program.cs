using System;

namespace ATM
{
    class Program
    {
        private const string Path = "Money.txt";

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

                switch (atm.CurrentState)
                {
                    case States.CombinationFailed:
                        Console.WriteLine("Enter other sum");
                        break;
                    case States.MoneyDeficiency:
                        Console.WriteLine("Insufficient money");
                        break;
                }
            }
        }
    }
}
