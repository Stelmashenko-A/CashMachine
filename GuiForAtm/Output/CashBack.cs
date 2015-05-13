using System.Collections.Generic;
using System.Linq;
using ATM;
using ATM.Utility;
using MetroFramework.Forms;

namespace GuiForAtm.Output
{
    public partial class CashBack : MetroForm
    {

        public CashBack(IEnumerable<MutablePair<Banknote, int>> data)
        {
            InitializeComponent();
            var list =
                (from variable in data where variable.Value != 0 select new PreparedMoney(variable)).ToList();
            metroGrid1.DataSource = list;
        }

        private void CashBack_Load(object sender, System.EventArgs e)
        {
            metroGrid1.Rows[0].Selected = false;
        }
    }
}
