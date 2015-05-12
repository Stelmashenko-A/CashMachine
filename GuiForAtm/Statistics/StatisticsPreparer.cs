using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ATM;

namespace GuiForAtm.Statistics
{
    internal static class StatisticsPreparer
    {
        public static List<PreparedRecord> Prepare(ATM.Statistics statistics)
        {
            var states = Configurator.Config();
            return
                statistics.Records.Select(
                    item =>
                        new PreparedRecord(item.TimeOfOperation.ToString(CultureInfo.InvariantCulture),
                            item.RequestedSum.ToString(CultureInfo.InvariantCulture), states[item.ResultOfOperation],
                            PrepareMoney(item.Money))).ToList();
        }

        private static string PrepareMoney(Money money)
        {
            if (money.TotalSum == 0)
            {

                return "0";
            }
            var sb = new StringBuilder();
            foreach (var variable in money.Banknotes.Where(variable => variable.Value != 0))
            {
                sb.Append("[" + variable.Key + "-" + variable.Value + "] ");
            }
            return sb.ToString();
        }
    }

}
