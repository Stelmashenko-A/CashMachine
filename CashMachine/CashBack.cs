using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashMachine
{
    internal class CashBack
    {
        public CashBack(List<int> pars)
        {
            Value = new Dictionary<int, int>();
            foreach (int par in pars)
            {
                Value.Add(par, 0);
            }
        }
        public States Result { get; set; }
        public Dictionary<int, int> Value { get; set; }
        public override string ToString()
        {
            var sb = new StringBuilder();
            switch (Result)
            {
                case States.AllCombinationsFailed:
                    sb.Append("Enter other sum");
                    break;
                case States.IsEmpty:
                    sb.Append("Cash machine is empty");
                    break;
                case States.MoneyDeficiency:
                    sb.Append("Not enough money");
                    break;
                case States.OK:
                    foreach (var variable in Value.Keys)
                    {
                        sb.Append(variable);
                        sb.Append(' ');
                        sb.Append(Value[variable]);
                        sb.Append('\n');
                    }
                    break;
            }
            return sb.ToString();
        }
    }
}
