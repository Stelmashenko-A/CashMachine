using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ATM.Utility;
using GuiForAtm.Output;

namespace GuiForAtm.Statistics
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            
        }

        public StatisticsForm(ATM.Stat.Statistics statistics)
        {
            var t = CultureInfo.CurrentCulture;
            InitializeComponent();
            t = CultureInfo.CurrentCulture;
            metroGrid1.DataSource = StatisticsPreparer.Prepare(statistics);
            metroGrid2.DataSource = statistics.Cassettes;
            

                labelTime.Text += statistics.StartTime;
            labelTotalSum.Text += statistics.TotalSum;
            labelRemainder.Text += statistics.Remainder;
            
        }
    }
}
