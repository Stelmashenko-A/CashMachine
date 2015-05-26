using System;
using System.Text;
using log4net;

namespace ATM.Viewers
{
    [Serializable]
    internal class LogViewer
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LogViewer));
        public string ToString(Money money, AtmState state)
        {
            var stringBuilder = new StringBuilder();
            try
            {
                stringBuilder.Append(Enum.GetName(typeof (AtmState), state) + ' ');
                foreach (var variable in money.Banknotes)
                {
                    stringBuilder.Append('[');
                    stringBuilder.Append(variable.Key);
                    stringBuilder.Append('-');
                    stringBuilder.Append(variable.Value);
                    stringBuilder.Append(']');
                    stringBuilder.Append('\n');
                }
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
