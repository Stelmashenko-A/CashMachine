using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM;
using ATM.Output;
using log4net;

namespace ConsoleInterfaceForAtm
{
    public class UserViewer : IMoneyViewer
    {
        private static Dictionary<AtmState, string> _errromMessage;
        private static readonly ILog Log = LogManager.GetLogger(typeof(UserViewer));
        public UserViewer(Dictionary<AtmState, string> errors)
        {
            _errromMessage = errors;
        }
        public string ToString(Money money, AtmState state)
        {
            if (money == null)
            {
                throw new ArgumentNullException("money");
            }
            var stringBuilder = new StringBuilder();
            try
            {
                if (state != AtmState.NoError) return _errromMessage[state];
                foreach (var variable in money.Banknotes.Where(variable => variable.Value != 0))
                {
                    stringBuilder.Append("[");
                    stringBuilder.Append(variable.Key);
                    stringBuilder.Append(',');
                    stringBuilder.Append(variable.Value);
                    stringBuilder.Append("]");
                }
            }
            catch (KeyNotFoundException ex)
            {
                Log.Error(ex);
                throw;
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
                throw;
            }
            return stringBuilder.ToString();
        }
    }
}
