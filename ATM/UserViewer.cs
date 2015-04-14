using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    internal class UserViewer : IMoneyWriter
    {
        private static Dictionary<AtmState, string> _errromMessage =
            ErrorReader.GetDefault();

        public UserViewer()
        {
        }

        public UserViewer(string path)
        {
            _errromMessage = ErrorReader.Read(path);
        }

        public string ToString(Money money, AtmState state)
        {
            
            var stringBuilder = new StringBuilder();
            if (state != AtmState.NoError) return _errromMessage[state].ToString();
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