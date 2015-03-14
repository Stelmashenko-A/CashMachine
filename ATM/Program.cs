using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            int requestedSum;
            
            var atm = new CashMachine();
            
            while (int.TryParse(Console.ReadLine(), out requestedSum))
            {
                var money = atm.Withdraw(requestedSum);
                Console.WriteLine(money.ToString());
            }
        }
    }
}
