using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using ATM.Utility;

namespace GuiForAtm
{
    class MoneyViewer
    {
        public MoneyViewer(MutablePair<Banknote, int> data)
        {
            Nominal = data.Key.Nominal;
            Number = data.Value;
        }

        public decimal Nominal { get; set; }
        public int Number { get; set; }
    }
}
