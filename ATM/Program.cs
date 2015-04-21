using System;
using ATM.Lang;
using ATM.Properties;
using log4net;
using log4net.Config;

//log4net
namespace ATM
{

    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        private static void Main()
        {
            XmlConfigurator.Configure();
            Log.Info("start");

            var errors = Configurator.Config();
            var userViewer = new UserViewer(errors);

            var moneyCassettes = CassetteReader.ReadCassette(Resources.PathToMoney);
            var atm = new CashMachine(new GreedyAlgorithm());
            atm.InsertCassettes(moneyCassettes);

            Console.WriteLine(Language.ExitMessage);
            

            while (true)
            {
                var input = Console.ReadLine();
                if (input == Language.ExitFlag) break;

                int requestedSum;
                if (!int.TryParse(input, out requestedSum) || requestedSum < 0)
                {
                    Console.WriteLine(Language.WrongInput);
                    continue;
                }

                var money = atm.Withdraw(requestedSum);
                Console.WriteLine(userViewer.ToString(money, atm.CurrentState));
            }
            Log.Info("end");
            
        }
    }
}
