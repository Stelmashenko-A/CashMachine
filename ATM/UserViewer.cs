using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    internal class UserViewer : IMoneyWriter
    {
        private static Dictionary<AtmState, string> _errromMessage;

        public UserViewer(Dictionary<AtmState, string> errors)
        {
            _errromMessage = errors;
        }
        public string ToString(Money money, AtmState state)
        {
            var stringBuilder = new StringBuilder();
            if (state != AtmState.NoError) return _errromMessage[state];
            foreach (var variable in money.Banknotes.Where(variable => variable.Value != 0))
            {
                stringBuilder.Append(variable.Key);
                stringBuilder.Append(' ');
                stringBuilder.Append(variable.Value);
                stringBuilder.Append('\n');
            }
            return stringBuilder.ToString();
        }
    }
}