using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using ATM;
using ATM.Input;
using ConsoleInterfaceForAtm.Language;
using ConsoleInterfaceForAtm.Preparers;

namespace ConsoleInterfaceForAtm
{
    internal static class CommandPerfomer
    {
        public static bool TryPerfom(string command, CashMachine atm, Dictionary<AtmState, string> errors, Statistics.Statistics statistics)
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
                WriteStatistics(statistics, errors);
                return true;
            }

            var strs = command.Split(' ');
            if (strs.Count() == 2 && strs[0] == ConsoleLanguagePack.InsertFlag)
            {
                strs = strs[1].Split('.');
                if (strs.Count() != 2)
                {
                    return false;
                }
                InsertCassette(command.Split(' ')[1], atm);
                return true;
            }
            if (strs.Count() == 2 && strs[0] == ConsoleLanguagePack.LanguageFlag)
            {
                RefreshLanguage(strs[1]);
                return true;
            }
            return false;
        }

        private static void RemoveCassettes(CashMachine atm)
        {
            atm.RemoveCassettes();
        }

        private static void OutHelp()
        {
            Console.WriteLine(ConsoleLanguagePack.Help);
        }

        private static void WriteStatistics(Statistics.Statistics statistics, Dictionary<AtmState, string> errors)
        {
            Console.WriteLine(StatisticsPreparer.Prepare(statistics, errors));
        }

        private static void InsertCassette(string path, CashMachine atm)
        {

            var reader = ReaderSelector.Select(path);
            if (reader == null)
            {
                Console.WriteLine(ConsoleLanguagePack.FormatIsntDetected);
                return;
            }
            try
            {
                atm.InsertCassettes(reader.Read(path));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(ConsoleLanguagePack.FileNotFound);
                return;
            }
            catch (SerializationException)
            {
                Console.WriteLine(ConsoleLanguagePack.FileCantBeRead);
                return;
            }
            Console.WriteLine(ConsoleLanguagePack.ReadSuccessfully);
        }

        private static void RefreshLanguage(string cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
            Console.Clear();
            Console.WriteLine(ConsoleLanguagePack.MainMessage);
        }
    }
}
