using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using ATM;
using ATM.Input;
using GuiForAtm.Lang;
using MetroFramework;

namespace GuiForAtm
{
    public partial class InputCassettes : Form
    {
        public InputCassettes()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            CashMachine atm;
            var gui = Owner as AtmGui;
            if (gui != null)
            {
                atm = gui.Atm;
            }
            else
            {
                throw new Exception("wrong owner");
            }
            var format = textBoxFileName.Text.Split('.').Last();
            format=format.ToLower();
            bool isFormatDetected = false;
            IReader<List<Cassette>> reader = null;
            if (format == "json")
            {
                isFormatDetected = true;
                reader = new JsonReader<List<Cassette>>();
            }
            if (format == "xml")
            {
                isFormatDetected = true;
                reader=new XmlReader<List<Cassette>>();
            }
            if (format == "csv")
            {
                isFormatDetected = true;
                reader=new CsvReader();
            }

            if (!isFormatDetected)
            {
                MetroMessageBox.Show(this, GUILanguagePack.WrongFormat);
                return;
            }
            try
            {
                atm.InsertCassettes(reader.Read(textBoxFileName.Text));
            }
            catch (FileNotFoundException)
            {
                MetroMessageBox.Show(this, GUILanguagePack.FileNotFound);
                return;
            }
            catch (SerializationException)
            {
                MetroMessageBox.Show(this, GUILanguagePack.ReadingFaild);
                return;
            }
            Close();
        }

        private void InputCassettes_Load(object sender, EventArgs e)
        {

        }
    }
}
