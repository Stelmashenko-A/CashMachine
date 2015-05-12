﻿using System.Windows.Forms;

namespace GuiForAtm.Statistics
{
    public partial class StatisticsForm : Form
    {
        public StatisticsForm()
        {
            InitializeComponent();
            
        }

        public StatisticsForm(ATM.Statistics statistics)
        {
            InitializeComponent();
            metroGrid1.DataSource = StatisticsPreparer.Prepare(statistics);
            labelTime.Text += statistics.StartTime;
            labelTotalSum.Text += statistics.TotalSum;
        }

        private void StatisticsForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}