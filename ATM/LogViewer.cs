using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    internal class LogViewer : IMoneyWriter
    {
        private static readonly Dictionary<AtmState, string> ErrromMessage =
            ErrorReader.GetDefault();
      
        public string ToString(Money money, AtmState state)
        {

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(ErrromMessage[state] + ' ');
            foreach (var variable in money.Banknotes)
            {
                stringBuilder.Append('[');
                stringBuilder.Append(variable.Key);
                stringBuilder.Append('-');
                stringBuilder.Append(variable.Value);
                stringBuilder.Append(']');
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
    }
}
