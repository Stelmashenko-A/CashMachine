using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            int requestedSum;
            var cassete = AtmReader.ReadCassete("Money.txt");
            var atm = new CashMachine(cassete, new GreedyAlgorithm());
            while (int.TryParse(Console.ReadLine(), out requestedSum))
            {
                var money = atm.Withdraw(requestedSum);
                Console.WriteLine(money.ToString());
            }
        }
    }
}
