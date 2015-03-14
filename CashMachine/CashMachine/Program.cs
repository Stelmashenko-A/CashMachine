using System;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");
            var cashMachine = new CashMachine();
            int amount;
            
            while (int.TryParse(Console.ReadLine(), out amount))
            {
                var cashBack = cashMachine.GetMoney(amount);
                Console.WriteLine(cashBack.ToString());
            }
        }
    }
}
