using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ATM;
using ATM.Utility;
using MetroFramework.Forms;

namespace GuiForAtm
{
    public partial class CashBack : MetroForm
    {

        public CashBack(List<MutablePair<Banknote, int>> data)
        {
            InitializeComponent();
            List<PreparedMoney> list =
                (from variable in data where variable.Value != 0 select new PreparedMoney(variable)).ToList();
            metroGrid1.DataSource = list;
            
            
        }

        private void CashBack_Load(object sender, System.EventArgs e)
        {
            metroGrid1.Rows[0].Selected = false;
        }
    }
}
