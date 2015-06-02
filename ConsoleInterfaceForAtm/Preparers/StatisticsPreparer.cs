using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ATM;
using ConsoleInterfaceForAtm.Language;

namespace ConsoleInterfaceForAtm.Preparers
{
    internal static class StatisticsPreparer
    {
        public static string Prepare(Statistics.Statistics statistics, Dictionary<AtmState, string> errors)
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
            sb.Append(ConsoleLanguagePack.Remainder + statistics.Remainder + "\n");
            sb.Append(ConsoleLanguagePack.AtmContext + "\n");
            foreach (var variable in statistics.Cassettes)
            {
                sb.Append(variable.Banknote.Nominal + " " + variable.Number + "\n");
            }
            return sb.ToString();
        }
    }
}