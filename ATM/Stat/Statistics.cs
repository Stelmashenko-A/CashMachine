using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ATM.Viewers;
using log4net;
using ServiceStack;

namespace ATM.Stat
{
    public class Statistics
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));
        public List<Record> Records { get; private set; }

        private readonly string _path;

        public decimal Remainder { get; private set; }

        public DateTime StartTime { get; private set; }

        public Statistics(string path, decimal remainder)
        {
            _path = path;
            Remainder = remainder;
            StartTime = DateTime.Now;
            Records = new List<Record>();
        }

        public void Add(decimal requestedSum, Money money, AtmState state)
        {
            Remainder -= money.TotalSum;
            Records.Add(new Record(DateTime.Now, requestedSum,money, state));
        }
        
        public decimal TotalSum
        {
            get
            {
                return Records.Where(variable => variable.ResultOfOperation == AtmState.NoError).Sum(variable => variable.Money.TotalSum);
            }
        }

        public void OutToFile()
        {
            if (_path.IsNullOrEmpty())
            {
                Log.Info("No path for outpunig stat");
                return;
            }

            Log.Info("Path to file = " + _path);
            var logViewer = new LogViewer();
            var streamWriter = new StreamWriter(new FileStream(_path, FileMode.OpenOrCreate));
            streamWriter.WriteLine("Cassete input at: "+ StartTime);
            foreach (var variable in Records)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(variable.TimeOfOperation);
                sb.Append(" Requested sum: " + variable.RequestedSum + " ");
                sb.Append(logViewer.ToString(variable.Money, variable.ResultOfOperation));
                streamWriter.WriteLine(sb.ToString());
            }
            streamWriter.WriteLine("Total sum = " + TotalSum);
            streamWriter.Close();
        }
    }
}
