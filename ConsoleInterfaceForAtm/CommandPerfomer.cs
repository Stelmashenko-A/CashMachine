using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using ATM;
using ATM.Input;

namespace ConsoleInterfaceForAtm
{
    static class CommandPerfomer
    {
        public static bool TryPerfom(string command, CashMachine atm, Dictionary<AtmState, string> errors)
        {
            if (command == ConsoleLanguagePack.HelpFlag)
            {
                OutHelp();
                return true;
            }

            if (command == ConsoleLanguagePack.RemoveFlag)
            {
                RemoveCassettes(atm);
                return true;
            }
            if (command == ConsoleLanguagePack.StatisticsFlag)
            {
                WriteStatistics(atm, errors);
                return true;
            }

            var strs = command.Split('-');
            if (strs.Count() != 2 || strs[0] != ConsoleLanguagePack.InsertFlag)
            {
                return false;
            }
            strs = strs[1].Split('.');
            if (strs.Count() != 2)
            {
                return false;
            }
            InsertCassette(command.Split('-')[1],atm);
            return true;

        }

        private static void RemoveCassettes(CashMachine atm)
        {
            atm.RemoveCassettes();
        }

        private static void OutHelp()
        {
            Console.WriteLine(ConsoleLanguagePack.Help);
        }

        private static void WriteStatistics(CashMachine atm, Dictionary<AtmState, string> errors)
        {
            Console.WriteLine(StatisticsPreparer.Prepare(atm.Statistics,errors));
        }

        private static void InsertCassette(string path, CashMachine atm)
        {
            IReader<List<Cassette>> reader = null;
            var format = path.Split('.').Last();

            format = format.ToLower();
            bool isFormatDetected = false;
            if (format == "json")
            {
                isFormatDetected = true;
                reader = new JsonReader<List<Cassette>>();
            }
            if (format == "xml")
            {
                isFormatDetected = true;
                reader = new XmlReader<List<Cassette>>();
            }
            if (format == "csv")
            {
                isFormatDetected = true;
                reader = new CsvReader();
            }

            if (!isFormatDetected)
            {
                Console.WriteLine(ConsoleLanguagePack.FormatIsntDetected);
                return;
            }
            try
            {
                atm.InsertCassettes(reader.Read(path));
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(ConsoleLanguagePack.FileNotFound);
                return;
            }
            catch (SerializationException exception)
            {
                Console.WriteLine(ConsoleLanguagePack.FileCantBeRead);
                return;
            }
            Console.WriteLine(ConsoleLanguagePack.ReadSuccessfully);
        }
    }
}
