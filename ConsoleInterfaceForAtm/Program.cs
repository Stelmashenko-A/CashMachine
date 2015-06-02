using System;
using System.Configuration;
using ATM;
using ATM.AtmOperations;
using ATM.Events;
using ATM.Utility;
using ConsoleInterfaceForAtm.Language;
using log4net;
using log4net.Config;

namespace ConsoleInterfaceForAtm
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        private static SignalHandler _signalHandler;

        private static CashMachine _atm;

        private static Statistics.Statistics _statistics;
        private static void Main()
        {

            XmlConfigurator.Configure();
            Log.Info("start");
            try
            {
                _signalHandler += HandleConsoleSignal;
                ConsoleHelper.SetSignalHandler(_signalHandler, true);

                var errors = Configurator.Config();

                 _atm = CashMachine.Deserialize(ConfigurationManager.AppSettings["SerializationAtm"]) ??
                  new CashMachine(new GreedyAlgorithm());
                 _statistics = Statistics.Statistics.Deserialize(ConfigurationManager.AppSettings["SerializationStatistics"]) ??
                   new Statistics.Statistics();

                AtmEvent.InsertCassettesEvent += _statistics.InsertCassettes;
                AtmEvent.WithdrawMoneyEvent += _statistics.WithdrawMoney;
                AtmEvent.RemoveCassettesEvent += _statistics.RemoveCassettes;
                
                var commandPerfomer = new Commands.CommandPerfomer(_atm, errors, _statistics);
                Console.WriteLine(ConsoleLanguagePack.MainMessage);

                while (true)
                {
                    var input = Console.ReadLine();
                    Log.Debug(input);
                    if (string.IsNullOrEmpty(input))
                    {
                        continue;
                    }
                    if (ConsoleLanguagePack.ExitFlags.Contains(input)) break;

                    if (!commandPerfomer.TryPerform(input))
                    {
                        Console.WriteLine(ConsoleLanguagePack.CommandNotFound);
                    }
                }
                _atm.Serialize(ConfigurationManager.AppSettings["SerializationAtm"]);
                _statistics.Serialize(ConfigurationManager.AppSettings["SerializationStatistics"]);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex);
            }

            Log.Info("end");

        }

        private static void HandleConsoleSignal(ConsoleSignal consoleSignal)
        {
            Log.Info("end (console close)");
        }
    }
}
