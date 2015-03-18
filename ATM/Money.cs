using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class Money
    {
        public List<MutablePair<Banknote, int>> Banknotes
        {
            get; private set;
        }

        public States Result
        {
            get; set;
        }

        public Money()
        {
            Banknotes = new List<MutablePair<Banknote, int>>();
        }

        public decimal TotalSum
        {
            get
            {
                return Banknotes.Sum(item => item.Value*item.Key.Nominal);
            }
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            switch (Result)
            {
                case States.CombinationFailed:
                    stringBuilder.Append("Enter other sum");
                    break;
                case States.MoneyDeficiency:
                    stringBuilder.Append("Not enough money");
                    break;
                case States.Success:
                    foreach (var variable in Banknotes)
                    {
                        stringBuilder.Append(variable.Key);
                        stringBuilder.Append(' ');
                        stringBuilder.Append(variable.Value);
                        stringBuilder.Append('\n');
                    }
                    break;
            }
            return stringBuilder.ToString();
        }
    }
}