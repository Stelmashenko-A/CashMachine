using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ATM;

namespace ConsoleInterfaceForAtm
{
    internal static class StatisticsPreparer
    {
        public static string Prepare(Statistics statistics, Dictionary<AtmState, string> errors)
        {
            var sb = new StringBuilder();
            sb.Append(ConsoleLanguagePack.TimeOfInsert + statistics.StartTime + "\n");
            UserViewer userViewer = new UserViewer(errors);
            foreach (var variable in statistics.Records)
            {
                sb.Append(variable.TimeOfOperation.ToString(CultureInfo.InvariantCulture) +
                          ConsoleLanguagePack.RequestedSum + variable.RequestedSum + ConsoleLanguagePack.AtmAnswer +
                          userViewer.ToString(variable.Money, variable.ResultOfOperation) + "\n");
            }
            sb.Append(ConsoleLanguagePack.TotalSum + statistics.TotalSum);
            return sb.ToString();
        }
    }
}
