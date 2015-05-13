using System;
using System.Collections.Generic;
using System.Configuration;
using ATM;
using ATM.AtmOperations;
using ATM.Input;
using ATM.Lang;
using ATM.Viewers;
using GuiForAtm.Lang;
using GuiForAtm.Output;
using GuiForAtm.Statistics;
using log4net;
using log4net.Config;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace GuiForAtm
{
    public partial class AtmGui : MetroForm
    {
        public readonly CashMachine Atm = new CashMachine(new GreedyAlgorithm(), ConfigurationManager.AppSettings["StatisticOut"]);
        private readonly Dictionary<AtmState, string> _errors;


        private static readonly ILog Log = LogManager.GetLogger(typeof(AtmGui));
        public AtmGui()
        {
            Log.Info("start");
            InitializeComponent();
            DienableButtonSelection();

            XmlConfigurator.Configure();
            _errors = Configurator.Config();
       
            IReader<List<Cassette>> reader = new XmlReader<List<Cassette>>();
            var moneyCassettes = reader.Read(ConfigurationManager.AppSettings["PathToMoney"]);
            Atm.InsertCassettes(moneyCassettes);

        }

        private void DienableButtonSelection()
        {
            foreach (var variable in Controls)
            {
                if (variable is MetroButton)
                {
                    (variable as MetroButton).UseSelectable = false;
                }
            }
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            if (buttonEnter.Enabled)
            {
                if (metroTextBox1.Text != "" && !char.IsDigit(metroTextBox1.Text[0]))
                {
                    metroTextBox1.Text = "";
                }
                var metroButton = sender as MetroButton;
                if (metroButton != null) metroTextBox1.Text += metroButton.Text;
            }
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text.Length > 0)
            {
                metroTextBox1.Text = metroTextBox1.Text.Remove(metroTextBox1.Text.Length - 1);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            decimal requestedSum;
            if (!decimal.TryParse(metroTextBox1.Text, out requestedSum) || requestedSum < 0)
            {
                metroTextBox1.Text = GUILanguagePack.InputIsWrong;
                Log.Info("Wrong input");

            }

            var money = Atm.Withdraw(requestedSum);
            if (Atm.CurrentState != AtmState.NoError)
            {
                metroTextBox1.Text = _errors[Atm.CurrentState];
                return;
            }
            CashBack cashBack = new CashBack(money.Banknotes);
            cashBack.ShowDialog();
        }

        private void buttonRemoveCassettes_Click(object sender, EventArgs e)
        {
            Atm.RemoveCassettes();
            metroTextBox1.Text = GUILanguagePack.NoCassettes;
            buttonEnter.Enabled = false;
        }

        private void buttonInputCassettes_Click(object sender, EventArgs e)
        {
            var inputCassettes = new InputCassettes();
            inputCassettes.ShowDialog(this);
            buttonEnter.Enabled = true;
            MetroMessageBox.Show(this, GUILanguagePack.SuccessInput);
            metroTextBox1.Text = "";

        }

        private void buttonStatistics_Click(object sender, EventArgs e)
        {
            var statisticsForm = new StatisticsForm(Atm.Statistics);
            statisticsForm.ShowDialog();
        }

        private void AtmGui_Load(object sender, EventArgs e)
        {

        }
    }
}
