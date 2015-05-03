using System;
using System.Collections.Generic;
using System.Configuration;
using ATM;
using ATM.AtmOperations;
using ATM.Input;
using ATM.Lang;
using ATM.Output;
using ATM.Utility;
using ATM.Viewers;
using log4net;
using log4net.Config;

namespace ConsoleInterfaceForAtm
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static readonly LogViewer LogViewer = new LogViewer();

        private static SignalHandler _signalHandler;

        private static void Main()
        {

            XmlConfigurator.Configure();
            Log.Info("start");
            try
            {
                _signalHandler += HandleConsoleSignal;
                ConsoleHelper.SetSignalHandler(_signalHandler, true);

                var errors = Configurator.Config();
                var userViewer = new UserViewer(errors);
                IReader<List<Cassette>> reader = new CsvReader();
                var moneyCassettes = reader.Read(ConfigurationManager.AppSettings["PathToMoney"]);
                var atm = new CashMachine(new GreedyAlgorithm());
                atm.InsertCassettes(moneyCassettes);

                Console.WriteLine(Language.ExitMessage);

                while (true)
                {
                    var input = Console.ReadLine();
                    Log.Debug(input);

                    if (input == Language.ExitFlag) break;

                    int requestedSum;
                    if (!int.TryParse(input, out requestedSum) || requestedSum < 0)
                    {
                        Console.WriteLine(Language.WrongInput);
                        Log.Info("Wrong input");
                        continue;
                    }

                    var money = atm.Withdraw(requestedSum);
                    Console.WriteLine(userViewer.ToString(money, atm.CurrentState));
                    Log.Debug(LogViewer.ToString(money, atm.CurrentState));
                }
                var cassettes = atm.RemoveCassettes();
                var writerJson = new JsonWriter<List<Cassette>>();
                writerJson.Write(cassettes, "cassette.json");
                var writerXml = new XmlWriter<List<Cassette>>();
                writerXml.Write(cassettes, "cassette.xml");
                var writerCsv = new CsvWriterer<List<Cassette>>();
                writerCsv.Write(cassettes, "cassette.csv");
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
