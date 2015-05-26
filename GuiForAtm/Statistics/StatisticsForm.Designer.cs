namespace GuiForAtm.Statistics
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.timeOfOperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestedSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultOfOperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moneyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preparedRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelTime = new MetroFramework.Controls.MetroLabel();
            this.labelTotalSum = new MetroFramework.Controls.MetroLabel();
            this.labelRemainder = new MetroFramework.Controls.MetroLabel();
            this.metroGrid2 = new MetroFramework.Controls.MetroGrid();
            this.cassetteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.preparedMoneyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.banknoteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparedRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cassetteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparedMoneyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // metroGrid1
            // 
            resources.ApplyResources(this.metroGrid1, "metroGrid1");
            this.metroGrid1.AllowUserToResizeRows = false;
            this.metroGrid1.AutoGenerateColumns = false;
            this.metroGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.timeOfOperationDataGridViewTextBoxColumn,
            this.requestedSumDataGridViewTextBoxColumn,
            this.resultOfOperationDataGridViewTextBoxColumn,
            this.moneyDataGridViewTextBoxColumn});
            this.metroGrid1.DataSource = this.preparedRecordBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // timeOfOperationDataGridViewTextBoxColumn
            // 
            this.timeOfOperationDataGridViewTextBoxColumn.DataPropertyName = "TimeOfOperation";
            resources.ApplyResources(this.timeOfOperationDataGridViewTextBoxColumn, "timeOfOperationDataGridViewTextBoxColumn");
            this.timeOfOperationDataGridViewTextBoxColumn.Name = "timeOfOperationDataGridViewTextBoxColumn";
            this.timeOfOperationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestedSumDataGridViewTextBoxColumn
            // 
            this.requestedSumDataGridViewTextBoxColumn.DataPropertyName = "RequestedSum";
            resources.ApplyResources(this.requestedSumDataGridViewTextBoxColumn, "requestedSumDataGridViewTextBoxColumn");
            this.requestedSumDataGridViewTextBoxColumn.Name = "requestedSumDataGridViewTextBoxColumn";
            this.requestedSumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // resultOfOperationDataGridViewTextBoxColumn
            // 
            this.resultOfOperationDataGridViewTextBoxColumn.DataPropertyName = "ResultOfOperation";
            resources.ApplyResources(this.resultOfOperationDataGridViewTextBoxColumn, "resultOfOperationDataGridViewTextBoxColumn");
            this.resultOfOperationDataGridViewTextBoxColumn.Name = "resultOfOperationDataGridViewTextBoxColumn";
            this.resultOfOperationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // moneyDataGridViewTextBoxColumn
            // 
            this.moneyDataGridViewTextBoxColumn.DataPropertyName = "Money";
            resources.ApplyResources(this.moneyDataGridViewTextBoxColumn, "moneyDataGridViewTextBoxColumn");
            this.moneyDataGridViewTextBoxColumn.Name = "moneyDataGridViewTextBoxColumn";
            this.moneyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // preparedRecordBindingSource
            // 
            this.preparedRecordBindingSource.DataSource = typeof(GuiForAtm.Statistics.PreparedRecord);
            // 
            // labelTime
            // 
            resources.ApplyResources(this.labelTime, "labelTime");
            this.labelTime.Name = "labelTime";
            // 
            // labelTotalSum
            // 
            resources.ApplyResources(this.labelTotalSum, "labelTotalSum");
            this.labelTotalSum.Name = "labelTotalSum";

            // 
            // labelRemainder
            // 
            resources.ApplyResources(this.labelRemainder, "labelRemainder");
            this.labelRemainder.Name = "labelRemainder";
            // 
            // metroGrid2
            // 
            resources.ApplyResources(this.metroGrid2, "metroGrid2");
            this.metroGrid2.AllowUserToResizeRows = false;
            this.metroGrid2.AutoGenerateColumns = false;
            this.metroGrid2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.metroGrid2.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.metroGrid2.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.metroGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.banknoteDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.totalSumDataGridViewTextBoxColumn});
            this.metroGrid2.DataSource = this.cassetteBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid2.DefaultCellStyle = dataGridViewCellStyle5;
            this.metroGrid2.EnableHeadersVisualStyles = false;
            this.metroGrid2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid2.Name = "metroGrid2";
            this.metroGrid2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.metroGrid2.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // cassetteBindingSource
            // 
            this.cassetteBindingSource.DataSource = typeof(ATM.Cassette);
            // 
            // preparedMoneyBindingSource
            // 
            this.preparedMoneyBindingSource.DataSource = typeof(GuiForAtm.Output.PreparedMoney);
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // banknoteDataGridViewTextBoxColumn
            // 
            this.banknoteDataGridViewTextBoxColumn.DataPropertyName = "Banknote";
            resources.ApplyResources(this.banknoteDataGridViewTextBoxColumn, "banknoteDataGridViewTextBoxColumn");
            this.banknoteDataGridViewTextBoxColumn.Name = "banknoteDataGridViewTextBoxColumn";
            this.banknoteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            resources.ApplyResources(this.numberDataGridViewTextBoxColumn, "numberDataGridViewTextBoxColumn");
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalSumDataGridViewTextBoxColumn
            // 
            this.totalSumDataGridViewTextBoxColumn.DataPropertyName = "TotalSum";
            resources.ApplyResources(this.totalSumDataGridViewTextBoxColumn, "totalSumDataGridViewTextBoxColumn");
            this.totalSumDataGridViewTextBoxColumn.Name = "totalSumDataGridViewTextBoxColumn";
            this.totalSumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StatisticsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroGrid2);
            this.Controls.Add(this.labelRemainder);
            this.Controls.Add(this.labelTotalSum);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.metroGrid1);
            this.Name = "StatisticsForm";
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparedRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cassetteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparedMoneyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.BindingSource preparedRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeOfOperationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestedSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultOfOperationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moneyDataGridViewTextBoxColumn;
        private MetroFramework.Controls.MetroLabel labelTime;
        private MetroFramework.Controls.MetroLabel labelTotalSum;
        private MetroFramework.Controls.MetroLabel labelRemainder;
        private MetroFramework.Controls.MetroGrid metroGrid2;
        private System.Windows.Forms.BindingSource preparedMoneyBindingSource;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.BindingSource cassetteBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn banknoteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalSumDataGridViewTextBoxColumn;

    }
}