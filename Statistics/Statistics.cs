using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using ATM;
using ATM.Events;
using log4net;

namespace Statistics
{
    [Serializable]
    public class Statistics
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));

        public List<Record> Records { get; private set; }

        public decimal Remainder { get; private set; }

        public DateTime StartTime { get; private set; }

        public List<Cassette> Cassettes { get; private set; }


        public Statistics()
        {
            Records=new List<Record>();
            Cassettes=new List<Cassette>();
        }
        public List<decimal> Nominals
        {
            get
            {
                if (Cassettes == null || Cassettes.Count == 0)
                {
                    return new List<decimal>();
                }
                return Cassettes.Select(variable => variable.Banknote.Nominal).ToList();
            }
        }

        public void InsertCassettes(object obj, InsertCassettesArgs args)
        {
            Records=new List<Record>();
            Remainder = args.Cassettes.Sum(item => item.TotalSum);
            Cassettes = args.Cassettes;
            StartTime = args.Time;
        }

        public void WithdrawMoney(object obj, WithdrawArgs args)
        {
            Remainder -= args.Money.TotalSum;
            Records.Add(new Record(DateTime.Now, args.RequestedSum, args.Money, args.ResultOfOperation));
            foreach (var variable in args.Money.Banknotes)
            {
                var variable1 = variable;
                foreach (var item in Cassettes.Where(item => item.Banknote.Nominal == variable1.Key.Nominal))
                {
                    item.RemoveBanknotes(variable.Value);
                }
            }
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


        public void RemoveCassettes(object obj, RemoveCassettesArgs args)
        {
            Remainder = 0;
            Cassettes = new List<Cassette>();
            Log.Info("Cassettes were remover");
        }

        public void Serialize(string fileName)
        {
            Stream testFileStream = File.Create(fileName);
            var serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, this);
            testFileStream.Close();
        }

        public static Statistics Deserialize(string fileName)
        {
            try
            {
                Stream stream = File.OpenRead(fileName);
                var deserializer = new BinaryFormatter();
                var cashMachine = (Statistics)deserializer.Deserialize(stream);
                stream.Close();
                return cashMachine;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
