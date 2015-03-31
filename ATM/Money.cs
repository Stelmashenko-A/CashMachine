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

        public ErrorMessages Result
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

            foreach (var variable in Banknotes)
            {
                if (variable.Value == 0) continue;
                stringBuilder.Append(variable.Key);
                stringBuilder.Append(' ');
                stringBuilder.Append(variable.Value);
                stringBuilder.Append('\n');
            }

            return stringBuilder.ToString();
        }

        public static Money Parse(List<MutablePair<decimal, int>> combination)
        {
            var money = new Money();
            foreach (var mutablePair in from variable in combination let banknote = new Banknote(variable.Key) select new MutablePair<Banknote, int>(banknote, variable.Value))
            {
                money.Banknotes.Add(mutablePair);
            }
            return money;
        }
    }
}