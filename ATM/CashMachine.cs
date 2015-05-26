using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using ATM.AtmOperations;
using ATM.Stat;
using ATM.Utility;
using ATM.Viewers;
using log4net;

namespace ATM
{
    [Serializable]
    public class CashMachine
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(CashMachine));

        private List<Cassette> _moneyCassettes = new List<Cassette>();

        readonly LogViewer _logViewer = new LogViewer();

        private Money _moneyForWithdraw;

        public Statistics Statistics;


        public decimal TotalSum
        {
            get
            {
                return _moneyCassettes.Sum(moneyCassette => moneyCassette.TotalSum);
            }
        }

        public AtmState CurrentState { get; private set; }

        public bool HaveMoneyForWithdraw { get; private set; }

        private readonly IBanknoteSelector _banknoteSelector;

        private Money PreparedMoney
        {
            get
            {
                var result = (Money)_moneyForWithdraw.Clone();
                HaveMoneyForWithdraw = false;
                return result;
            }
            set
            {
                _moneyForWithdraw = value;
                HaveMoneyForWithdraw = true;
            }
        }

        public CashMachine(IBanknoteSelector banknoteSelector)
        {
            _banknoteSelector = banknoteSelector;
            Statistics = new Statistics(0,new List<Cassette>());
        }


        public Money Withdraw(decimal requestedSum)
        {
            Log.Info("Request for withdrw "+ requestedSum );
            AtmState result;
            List<MutablePair<decimal, int>> combination;
            var moneyForWithdraw = new Money();

            if (_banknoteSelector.TrySelect(ConvertCassettes(), requestedSum, out result, out combination))
            {
                UpdateCassettes(combination);
                moneyForWithdraw = (Money)PreparedMoney.Clone();
            }
            CurrentState = result;
            Log.Info(_logViewer.ToString(moneyForWithdraw,result));
            Statistics.Update(requestedSum,moneyForWithdraw, CurrentState,new List<Cassette>(_moneyCassettes));
            return moneyForWithdraw;
        }

        public List<MutablePair<decimal, int>> ConvertCassettes()
        {
            CurrentState = AtmState.NoError;
            Log.Debug(CurrentState);
            return
                _moneyCassettes.Select(item => new MutablePair<decimal, int>(item.Banknote.Nominal, item.Number))
                    .ToList();
        }

        private void UpdateCassettes(List<MutablePair<decimal, int>> combination)
        {
            try
            {
                if (combination == null)
                {
                    throw new ArgumentNullException("combination");
                }
                Money money;
                if (!Money.TryParse(combination, out money))
                {
                    throw new FormatException("combination");
                }

                PreparedMoney = money;
                Log.Debug(_logViewer.ToString(PreparedMoney,CurrentState));

                foreach (var variable in PreparedMoney.Banknotes)
                {
                    var variableTmp = variable;
                    Log.Debug(variable);
                    foreach (var item in _moneyCassettes.Where(item => item.Banknote.Nominal == variableTmp.Key.Nominal)
                        )
                    {
                        item.RemoveBanknotes(variable.Value);
                    }
                }
                Log.Info("Cassettes has been updated");
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
                throw;
            }
            catch (FormatException ex)
            {
                Log.Error("Can't parse combination from algoritm (combintion can be equal null)", ex);
                throw;
            }

        }

        public void InsertCassettes(List<Cassette> cassetes)
        {
            Log.Debug(cassetes);
            _moneyCassettes=new List<Cassette>();
            try
            {
                if (cassetes == null)
                {
                    throw new ArgumentNullException("cassetes");
                }
                foreach (var variable in cassetes)
                {
                    _moneyCassettes.Add((Cassette) variable.Clone());
                }
                Log.Info("Cassettes has been inserted");
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex);
                throw;
            }
            Statistics = new Statistics(TotalSum, new List<Cassette>(_moneyCassettes));
        }

        public List<Cassette> RemoveCassettes()
        {
            var tmp = _moneyCassettes;
            _moneyCassettes = null;
            Statistics.RemoveCassettes();
            return tmp;
        }

        public void Serialize(string fileName)
        {
            Stream testFileStream = File.Create(fileName);
            var serializer = new BinaryFormatter();
            serializer.Serialize(testFileStream, this);
            testFileStream.Close();
        }

        public static CashMachine Deserialize(string fileName)
        {
            try
            {
                Stream stream = File.OpenRead(fileName);
                var deserializer = new BinaryFormatter();
                var cashMachine = (CashMachine)deserializer.Deserialize(stream);
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