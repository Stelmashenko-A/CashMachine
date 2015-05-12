namespace GuiForAtm
{
    partial class InputCassettes
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
            this.textBoxFileName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabelFileName = new MetroFramework.Controls.MetroLabel();
            this.buttonEnter = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Lines = new string[] {
        "Cassette.xml"};
            this.textBoxFileName.Location = new System.Drawing.Point(12, 51);
            this.textBoxFileName.MaxLength = 32767;
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.PasswordChar = '\0';
            this.textBoxFileName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxFileName.SelectedText = "";
            this.textBoxFileName.Size = new System.Drawing.Size(260, 23);
            this.textBoxFileName.TabIndex = 0;
            this.textBoxFileName.Text = "Cassette.xml";
            this.textBoxFileName.UseSelectable = true;
            // 
            // metroLabelFileName
            // 
            this.metroLabelFileName.AutoSize = true;
            this.metroLabelFileName.Location = new System.Drawing.Point(13, 26);
            this.metroLabelFileName.Name = "metroLabelFileName";
            this.metroLabelFileName.Size = new System.Drawing.Size(106, 19);
            this.metroLabelFileName.TabIndex = 2;
            this.metroLabelFileName.Text = "Enter path to file";
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(12, 81);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(260, 23);
            this.buttonEnter.TabIndex = 3;
            this.buttonEnter.Text = "InserCassettes";
            this.buttonEnter.UseSelectable = true;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // InputCassettes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 132);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.metroLabelFileName);
            this.Controls.Add(this.textBoxFileName);
            this.Name = "InputCassettes";
            this.Text = "InputCassettes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox textBoxFileName;
        private MetroFramework.Controls.MetroLabel metroLabelFileName;
        private MetroFramework.Controls.MetroButton buttonEnter;
    }
}