using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            int requestedSum;
            var moneyCassettes = CassetteReader.ReadCassette("Money.txt");
            var atm = new CashMachine(moneyCassettes, new GreedyAlgorithm());
            while (int.TryParse(Console.ReadLine(), out requestedSum))
            {
                var money = atm.Withdraw(requestedSum);
                Console.WriteLine(money.ToString());
            }
        }
    }
}
