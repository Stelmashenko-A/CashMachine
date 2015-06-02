using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ATM;
using ATM.AtmOperations;
using ATM.Events;
using ATM.Input;
using ATM.Utility;
using GuiForAtm.Lang;
using GuiForAtm.Output;
using GuiForAtm.Statistics;
using log4net;
using log4net.Config;
using MetroFramework.Controls;

namespace GuiForAtm
{
    public partial class AtmGui : Form
    {
        public readonly CashMachine Atm;
        public readonly global::Statistics.Statistics Stat;
        private readonly Dictionary<AtmState, string> _errors;
        private Operations _operation;

        private static readonly ILog Log = LogManager.GetLogger(typeof(AtmGui));
        public AtmGui()
        {
            Log.Info("start");
            InitializeComponent();
            
            DisenableButtonSelection();

            XmlConfigurator.Configure();
            _errors = Configurator.Config();
            Atm = CashMachine.Deserialize(ConfigurationManager.AppSettings["SerializationAtm"]) ??
                  new CashMachine(new GreedyAlgorithm());
            Stat = global::Statistics.Statistics.Deserialize(ConfigurationManager.AppSettings["SerializationStatistics"]) ??
                  new global::Statistics.Statistics();
            AtmEvent.InsertCassettesEvent += Stat.InsertCassettes;
            AtmEvent.WithdrawMoneyEvent += Stat.WithdrawMoney;
            AtmEvent.RemoveCassettesEvent += Stat.RemoveCassettes;

            _operation = Operations.Withdraw;
            InitializeBanknotes();
        }

        private void InitializeBanknotes()
        {
            if (Stat.Nominals.Count == 0)
            {
                labelBanknotes.Text = GUILanguagePack.AtmIsEmpty;
                return;
            }
            var sb = new StringBuilder();
            sb.Append(GUILanguagePack.Banknotes + ":");
            foreach (var variable in Stat.Nominals)
            {
                sb.Append(variable + ", ");
            }
            sb.Remove(sb.Length - 2, 2);
            labelBanknotes.Text = sb.ToString();
        }

        private void DisenableButtonSelection()
        {
            foreach (var variable in Controls.OfType<MetroButton>())
            {
                variable.UseSelectable = false;
            }
        }

        private void OutMoney(IEnumerable<MutablePair<Banknote, int>> data)
        {
            Log.Info("out money");
            var list =
                (from variable in data where variable.Value != 0 select new PreparedMoney(variable)).ToList();
            metroGrid1.DataSource = list;
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (_operation != Operations.Withdraw) return;
            decimal requestedSum;
            if (!decimal.TryParse(Screen.Text, out requestedSum) || requestedSum < 0)
            {
                Screen.Text = GUILanguagePack.WrongInput;
                Log.Info("Wrong input");
                return;
            }

            var money = Atm.Withdraw(requestedSum);
            if (Atm.CurrentState != AtmState.NoError)
            {
                Screen.Text = _errors[Atm.CurrentState];
                return;
            }
            OutMoney(money.Banknotes);
            InitializeBanknotes();
        }

        private void inputCassettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = @"Json (*.json)|*.json|Xml (*.xml*)|*.xml*|CSV (*.csv*)|*.csv*"
            };
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            var reader = ReaderSelector.Select(openFileDialog.FileName);
            Atm.InsertCassettes(reader.Read(openFileDialog.FileName));
            buttonEnter.Enabled = true;
        }

        private void removeCassettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Atm.RemoveCassettes();
            buttonEnter.Enabled = false;
            InitializeBanknotes();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var statisticsForm = new StatisticsForm(Stat);
            statisticsForm.ShowDialog();
        }

        private void Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if ((int) e.KeyData == 112)
            {
                inputCassettesToolStripMenuItem_Click(null,null);
            }
            if ((int)e.KeyData == 113)
            {
                removeCassettesToolStripMenuItem_Click(null,null);
            }
            if ((int)e.KeyData == 114)
            {
                statisticsToolStripMenuItem_Click(null,null);
            }
            if ((int)e.KeyData == 115)
            {
                withdrawToolStripMenuItem_Click(null,null);
            }

        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _operation=Operations.Withdraw;
            InitializeBanknotes();
            
        }

        private void pictureBoxRussian_Click(object sender, EventArgs e)
        {
            LocalizeForm(this, "ru");
        }

        private void pictureBoxEnglish_Click(object sender, EventArgs e)
        {
            LocalizeForm(this,"en");
        }

        public void LocalizeForm(Form someForm, string cultureInfo)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureInfo);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureInfo);
            Controls.Clear();
            InitializeComponent();
            InitializeBanknotes();
            Refresh();
        }

        private void AtmGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            Atm.Serialize(ConfigurationManager.AppSettings["SerializationAtm"]);
            Stat.Serialize(ConfigurationManager.AppSettings["SerializationStatistics"]);
        }

        private void AtmGui_Load(object sender, EventArgs e)
        {

        }
    }
}
