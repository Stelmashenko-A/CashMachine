using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using ATM;
using ATM.AtmOperations;
using ATM.Input;
using ATM.Utility;
using GuiForAtm.Lang;
using GuiForAtm.Output;
using GuiForAtm.Statistics;
using log4net;
using log4net.Config;
using MetroFramework;
using MetroFramework.Controls;

namespace GuiForAtm
{
    public partial class AtmGui : Form
    {
        public readonly CashMachine Atm;
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
            Atm = CashMachine.Deserialize(ConfigurationManager.AppSettings["SerializationFile"]);
            if (Atm == null)
            {
                Atm = new CashMachine(new GreedyAlgorithm());
                IReader<List<Cassette>> reader = new XmlReader<List<Cassette>>();
                var moneyCassettes = reader.Read(ConfigurationManager.AppSettings["PathToMoney"]);
                Atm.InsertCassettes(moneyCassettes);
                InitializeBanknotes();
            }
            _operation = Operations.Withdraw;
        }

        private void InitializeBanknotes()
        {
            if (Atm.Statistics.Nominals.Count == 0)
            {
                labelBanknotes.Text = GUILanguagePack.AtmIsEmpty;
                return;
            }
            var sb = new StringBuilder();
            sb.Append(GUILanguagePack.Banknotes + ":");
            foreach (var variable in Atm.Statistics.Nominals)
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
            var list =
                (from variable in data where variable.Value != 0 select new PreparedMoney(variable)).ToList();
            metroGrid1.DataSource = list;
        }
        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (_operation == Operations.Withdraw)
            {
                decimal requestedSum;
                if (!decimal.TryParse(Screen.Text, out requestedSum) || requestedSum < 0)
                {
                    Screen.Text = GUILanguagePack.InputIsWrong;
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
                return;
            }
            if (_operation != Operations.Input) return;
            var format = Screen.Text.Split('.').Last();
            format = format.ToLower();
            var isFormatDetected = false;
            IReader<List<Cassette>> reader = null;
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
                MetroMessageBox.Show(this, GUILanguagePack.WrongFormat,GUILanguagePack.Notification);
                return;
            }
            try
            {
                Atm.InsertCassettes(reader.Read(Screen.Text));
            }
            catch (FileNotFoundException)
            {

                MetroMessageBox.Show(this, GUILanguagePack.FileNotFound, GUILanguagePack.Notification);
            }
            catch (SerializationException)
            {
                MetroMessageBox.Show(this, GUILanguagePack.ReadingFaild,GUILanguagePack.Notification);
            }
        }

        private void inputCassettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelCommand.Text = GUILanguagePack.InputCassettes;
            _operation=Operations.Input;
        }

        private void removeCassettesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Atm.RemoveCassettes();
            buttonEnter.Enabled = false;
            InitializeBanknotes();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var statisticsForm = new StatisticsForm(Atm.Statistics);
            LocalizeForm(statisticsForm, new CultureInfo("ru"));
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

        private void AtmGui_Load(object sender, EventArgs e)
        {

        }

        private void withdrawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _operation=Operations.Withdraw;
            InitializeBanknotes();
            
        }

        private void pictureBoxRussian_Click(object sender, EventArgs e)
        {
            LocalizeForm(this, new CultureInfo("ru"));
            InitializeBanknotes();
            Refresh();
        }

        private void pictureBoxEnglish_Click(object sender, EventArgs e)
        {
            LocalizeForm(this,new CultureInfo("en"));
            InitializeBanknotes();
            Refresh();
        }

        public void LocalizeForm(Form someForm, CultureInfo cultureInfo)
        {
            Type someFormType = someForm.GetType();
            ResourceManager res = new ResourceManager(someFormType);

  
            string[] properties = { "Text", "Location" };

            foreach (string propertyName in properties)
            {
                foreach (var fieldInfo in someFormType.GetFields(BindingFlags.NonPublic | BindingFlags.DeclaredOnly | BindingFlags.Instance))
                {
                    var propertyInfo = fieldInfo.FieldType.GetProperty(propertyName);
                    if (propertyInfo == null)
                        continue;
                    var objProperty = res.GetObject(fieldInfo.Name + '.' + propertyInfo.Name, cultureInfo);
                    if (objProperty == null) continue;
                    var field = fieldInfo.GetValue(someForm);
                    if (field != null)
                        propertyInfo.SetValue(field, objProperty, null);
                }
                var propertyInfo1 = someFormType.GetProperty(propertyName);
                if (propertyInfo1 == null)
                    continue;
                var objProperty1 = res.GetObject("$this." + propertyInfo1.Name, cultureInfo);
                if (objProperty1 == null) continue;
                propertyInfo1.SetValue(someForm, objProperty1, null);
            }
        }

        private void AtmGui_FormClosing(object sender, FormClosingEventArgs e)
        {
            Atm.Serialize(ConfigurationManager.AppSettings["SerializationFile"]);
        }
    }
}
