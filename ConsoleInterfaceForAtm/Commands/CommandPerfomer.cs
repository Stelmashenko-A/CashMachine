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

namespace ConsoleInterfaceForAtm.Commands
{
    internal class CommandPerfomer
    {
        private readonly Dictionary<string, Action> _commands;
        private readonly CashMachine _atm;
        private readonly Dictionary<AtmState, string> _errors;
        private readonly Statistics.Statistics _statistics;
        private string _parametres;
        private bool _result;
        private readonly UserViewer _userViewer;

        public CommandPerfomer(CashMachine atm, Dictionary<AtmState, string> errors, Statistics.Statistics statistics)
        {
            _atm = atm;
            _errors = errors;
            _statistics = statistics;

            _commands = new Dictionary<string, Action>
            {
                {ConsoleLanguagePack.HelpFlag, HelpCommand},
                {ConsoleLanguagePack.InsertFlag, InsertCassettesCommand},
                {ConsoleLanguagePack.LanguageFlag, RefreshLanguageCommand},
                {ConsoleLanguagePack.RemoveFlag, RemoveCasssettesCommand},
                {ConsoleLanguagePack.StatisticsFlag, StatisticsCommand}
            };
            _userViewer = new UserViewer(errors);
        }

        public bool TryPerform(string command)
        {
            _result = false;
            var strs = command.Split(' ');
            if (strs.Count() > 2)
            {
                return false;
            }
            if (strs.Count() == 2)
            {
                _parametres = strs[1];
            }
            command = strs[0].ToLower();
            if (_commands.ContainsKey(command))
            {
                _commands[command].Invoke();
            }

            if (_result) return _result;
            if (strs.Count() != 1) return _result;
            decimal requestedSum;
            if (!decimal.TryParse(strs[0], out requestedSum)) return _result;
            WithdrawCommand(requestedSum);
            _result = true;
            return _result;

        }

        private void HelpCommand()
        {
            Console.WriteLine(ConsoleLanguagePack.Help);
            _result = true;
        }

        private void InsertCassettesCommand()
        {

            var reader = ReaderSelector.Select(_parametres);
            if (reader == null)
            {
                Console.WriteLine(ConsoleLanguagePack.FormatIsntDetected);
                _result = true;
            }
            try
            {
                if (reader != null) _atm.InsertCassettes(reader.Read(_parametres));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(ConsoleLanguagePack.FileNotFound);
                _result = true;

            }
            catch (SerializationException)
            {
                Console.WriteLine(ConsoleLanguagePack.FileCantBeRead);
                _result = true;

            }
            catch
            {
                _result = false;
            }
            Console.WriteLine(ConsoleLanguagePack.ReadSuccessfully);
            _result = true;
        }

        private void RefreshLanguageCommand()
        {

            if (string.IsNullOrEmpty(_parametres))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(_parametres);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(_parametres);
            }
            else
            {
                _result = false;
                return;
            }
            Console.Clear();
            Console.WriteLine(ConsoleLanguagePack.MainMessage);
            _result = true;
        }

        private void RemoveCasssettesCommand()
        {
            _atm.RemoveCassettes();
            _result = true;
        }

        private void StatisticsCommand()
        {
            Console.WriteLine(StatisticsPreparer.Prepare(_statistics, _errors));
            _result = true;
        }

        private void WithdrawCommand(decimal sum)
        {
            if (sum < 0)
            {
                Console.WriteLine(ConsoleLanguagePack.NegativeSum);
            }
            var money = _atm.Withdraw(sum);
            Console.WriteLine(_userViewer.ToString(money, _atm.CurrentState));
        }
    }
}
