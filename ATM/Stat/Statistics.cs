using System;
using System.Collections.Generic;
using System.Linq;
using log4net;

namespace ATM.Stat
{
    [Serializable]
    public class Statistics
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));

        public List<Record> Records { get; private set; }

        public decimal Remainder { get; private set; }

        public DateTime StartTime { get; private set; }

        public List<Cassette> Cassettes { get; private set; }

        public Statistics(decimal remainder, List<Cassette> cassettes)
        {
            Remainder = remainder;
            StartTime = DateTime.Now;
            Records = new List<Record>();
            Cassettes = cassettes;
            Log.Info("Statistic initialize");
        }

        public List<decimal> Nominals
        {
            get { return Cassettes.Select(variable => variable.Banknote.Nominal).ToList(); }
        }

        public void Update(decimal requestedSum, Money money, AtmState state, List<Cassette> cassettes)
        {
            Remainder -= money.TotalSum;
            Records.Add(new Record(DateTime.Now, requestedSum, money, state));
            Cassettes = cassettes;
            Log.Info("Statistic initialize at");
        }


        public decimal TotalSum
        {
            get
            {
                return
                    Records.Where(variable => variable.ResultOfOperation == AtmState.NoError)
                        .Sum(variable => variable.Money.TotalSum);
            }
        }


        public void RemoveCassettes()
        {
            Remainder = 0;
            Cassettes = new List<Cassette>();
            Log.Info("Cassettes were remover");
        }
    }
}
