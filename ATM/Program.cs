using System;

namespace ATM
{
    class Program
    {
        static void Main()
        {
            const int requestedSum = 385;
            
            var atm = new CashMachine();
            
            var money = atm.Withdraw(requestedSum);

            Console.WriteLine(money);
            Console.Read();
        }
    }
}
