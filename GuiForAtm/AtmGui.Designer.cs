namespace GuiForAtm
{
    partial class AtmGui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtmGui));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelCommand = new MaterialSkin.Controls.MaterialLabel();
            this.Screen = new MetroFramework.Controls.MetroTextBox();
            this.labelBanknotes = new MaterialSkin.Controls.MaterialLabel();
            this.metroGrid1 = new MetroFramework.Controls.MetroGrid();
            this.nominalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.preparedMoneyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonEnter = new MetroFramework.Controls.MetroButton();
            this.inputCassettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeCassettesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statisticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.withdrawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pictureBoxEnglish = new System.Windows.Forms.PictureBox();
            this.pictureBoxRussian = new System.Windows.Forms.PictureBox();
            this.cashMachineBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparedMoneyBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnglish)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRussian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashMachineBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCommand
            // 
            resources.ApplyResources(this.labelCommand, "labelCommand");
            this.labelCommand.Depth = 0;
            this.labelCommand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCommand.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelCommand.Name = "labelCommand";
            // 
            // Screen
            // 
            resources.ApplyResources(this.Screen, "Screen");
            this.Screen.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.Screen.Lines = new string[0];
            this.Screen.MaxLength = 32767;
            this.Screen.Multiline = true;
            this.Screen.Name = "Screen";
            this.Screen.PasswordChar = '\0';
            this.Screen.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Screen.SelectedText = "";
            this.Screen.UseSelectable = true;
            this.Screen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Screen_KeyDown);
            // 
            // labelBanknotes
            // 
            resources.ApplyResources(this.labelBanknotes, "labelBanknotes");
            this.labelBanknotes.Depth = 0;
            this.labelBanknotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelBanknotes.MouseState = MaterialSkin.MouseState.HOVER;
            this.labelBanknotes.Name = "labelBanknotes";
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
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.metroGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.metroGrid1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nominalDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn});
            this.metroGrid1.DataSource = this.preparedMoneyBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.metroGrid1.DefaultCellStyle = dataGridViewCellStyle2;
            this.metroGrid1.EnableHeadersVisualStyles = false;
            this.metroGrid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.metroGrid1.MultiSelect = false;
            this.metroGrid1.Name = "metroGrid1";
            this.metroGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.metroGrid1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.metroGrid1.RowHeadersVisible = false;
            this.metroGrid1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.metroGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.metroGrid1.Style = MetroFramework.MetroColorStyle.Blue;
            // 
            // nominalDataGridViewTextBoxColumn
            // 
            this.nominalDataGridViewTextBoxColumn.DataPropertyName = "Nominal";
            resources.ApplyResources(this.nominalDataGridViewTextBoxColumn, "nominalDataGridViewTextBoxColumn");
            this.nominalDataGridViewTextBoxColumn.Name = "nominalDataGridViewTextBoxColumn";
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            resources.ApplyResources(this.numberDataGridViewTextBoxColumn, "numberDataGridViewTextBoxColumn");
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            // 
            // preparedMoneyBindingSource
            // 
            this.preparedMoneyBindingSource.DataSource = typeof(GuiForAtm.Output.PreparedMoney);
            // 
            // buttonEnter
            // 
            resources.ApplyResources(this.buttonEnter, "buttonEnter");
            this.buttonEnter.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.UseSelectable = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // inputCassettesToolStripMenuItem
            // 
            resources.ApplyResources(this.inputCassettesToolStripMenuItem, "inputCassettesToolStripMenuItem");
            this.inputCassettesToolStripMenuItem.Name = "inputCassettesToolStripMenuItem";
            this.inputCassettesToolStripMenuItem.Click += new System.EventHandler(this.inputCassettesToolStripMenuItem_Click);
            // 
            // removeCassettesToolStripMenuItem
            // 
            resources.ApplyResources(this.removeCassettesToolStripMenuItem, "removeCassettesToolStripMenuItem");
            this.removeCassettesToolStripMenuItem.Name = "removeCassettesToolStripMenuItem";
            this.removeCassettesToolStripMenuItem.Click += new System.EventHandler(this.removeCassettesToolStripMenuItem_Click);
            // 
            // statisticsToolStripMenuItem
            // 
            resources.ApplyResources(this.statisticsToolStripMenuItem, "statisticsToolStripMenuItem");
            this.statisticsToolStripMenuItem.Name = "statisticsToolStripMenuItem";
            this.statisticsToolStripMenuItem.Click += new System.EventHandler(this.statisticsToolStripMenuItem_Click);
            // 
            // withdrawToolStripMenuItem
            // 
            resources.ApplyResources(this.withdrawToolStripMenuItem, "withdrawToolStripMenuItem");
            this.withdrawToolStripMenuItem.Name = "withdrawToolStripMenuItem";
            this.withdrawToolStripMenuItem.Click += new System.EventHandler(this.withdrawToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inputCassettesToolStripMenuItem,
            this.removeCassettesToolStripMenuItem,
            this.statisticsToolStripMenuItem,
            this.withdrawToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // pictureBoxEnglish
            // 
            resources.ApplyResources(this.pictureBoxEnglish, "pictureBoxEnglish");
            this.pictureBoxEnglish.Image = global::GuiForAtm.Properties.Resources._0000026797_velikobritaniia_enl;
            this.pictureBoxEnglish.Name = "pictureBoxEnglish";
            this.pictureBoxEnglish.TabStop = false;
            this.pictureBoxEnglish.Click += new System.EventHandler(this.pictureBoxEnglish_Click);
            // 
            // pictureBoxRussian
            // 
            resources.ApplyResources(this.pictureBoxRussian, "pictureBoxRussian");
            this.pictureBoxRussian.Image = global::GuiForAtm.Properties.Resources._409002_original;
            this.pictureBoxRussian.Name = "pictureBoxRussian";
            this.pictureBoxRussian.TabStop = false;
            this.pictureBoxRussian.Click += new System.EventHandler(this.pictureBoxRussian_Click);
            // 
            // cashMachineBindingSource
            // 
            this.cashMachineBindingSource.DataSource = typeof(ATM.CashMachine);
            // 
            // AtmGui
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxEnglish);
            this.Controls.Add(this.pictureBoxRussian);
            this.Controls.Add(this.metroGrid1);
            this.Controls.Add(this.labelBanknotes);
            this.Controls.Add(this.Screen);
            this.Controls.Add(this.labelCommand);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonEnter);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AtmGui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AtmGui_FormClosing);
            this.Load += new System.EventHandler(this.AtmGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.metroGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preparedMoneyBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEnglish)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRussian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cashMachineBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel labelCommand;
        private MetroFramework.Controls.MetroTextBox Screen;
        private System.Windows.Forms.BindingSource cashMachineBindingSource;
        private MaterialSkin.Controls.MaterialLabel labelBanknotes;
        private MetroFramework.Controls.MetroGrid metroGrid1;
        private System.Windows.Forms.BindingSource preparedMoneyBindingSource;
        private MetroFramework.Controls.MetroButton buttonEnter;
        private System.Windows.Forms.ToolStripMenuItem inputCassettesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeCassettesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statisticsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem withdrawToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox pictureBoxRussian;
        private System.Windows.Forms.PictureBox pictureBoxEnglish;
        private System.Windows.Forms.DataGridViewTextBoxColumn nominalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;

    }
}