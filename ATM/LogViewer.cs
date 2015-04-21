using System;
using System.Text;

namespace ATM
{
    internal class LogViewer : IMoneyWriter
    {
     
        public string ToString(Money money, AtmState state)
        {

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(Enum.GetName(typeof (AtmState),state) + ' ');
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
