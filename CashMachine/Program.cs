using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            CashMachine cashMachine = new CashMachine();
            CashBack cashBack = cashMachine.GetMoney(300000000);
            if(cashBack.Result == States.OK)
            {
                Console.WriteLine("ok");
            }
            Console.ReadKey();
        }
    }
}
