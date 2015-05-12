using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATM;
using ATM.Input;
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
            if (Owner is AtmGui)
            {
                atm = (Owner as AtmGui).Atm;
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
                MetroMessageBox.Show(this, "Format isn't detected");
                return;
            }
            try
            {
                atm.InsertCassettes(reader.Read(textBoxFileName.Text));
            }
            catch (FileNotFoundException exception)
            {
                MetroMessageBox.Show(this, "File not found");
                return;
            }
            catch (System.Runtime.Serialization.SerializationException exception)
            {
                MetroMessageBox.Show(this, "File has wrong format");
                return;
            }
            this.Close();
        }
    }
}
