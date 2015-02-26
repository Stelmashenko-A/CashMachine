using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    class CashBack
    {
        public CashBack(List<int> pars)
        {
            Value = new Dictionary<int, int>();
            foreach(int par in pars)
            {
                Value.Add(par, 0);
            }

        }
        public States Result { get; set; }
        public Dictionary<int, int> Value { get; set; }

    }
}
