namespace InstrumentShopWinForm
{
    partial class frmNewInstrument
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWarrantyPeriod = new System.Windows.Forms.TextBox();
            this.txtImportDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Warranty Period";
            // 
            // txtWarrantyPeriod
            // 
            this.txtWarrantyPeriod.Location = new System.Drawing.Point(149, 275);
            this.txtWarrantyPeriod.MaxLength = 30;
            this.txtWarrantyPeriod.Name = "txtWarrantyPeriod";
            this.txtWarrantyPeriod.Size = new System.Drawing.Size(148, 22);
            this.txtWarrantyPeriod.TabIndex = 33;
            // 
            // txtImportDate
            // 
            this.txtImportDate.Location = new System.Drawing.Point(149, 310);
            this.txtImportDate.MaxLength = 10;
            this.txtImportDate.Name = "txtImportDate";
            this.txtImportDate.Size = new System.Drawing.Size(148, 22);
            this.txtImportDate.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 34;
            this.label7.Text = "Import Date";
            // 
            // frmNewInstrument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(463, 393);
            this.Controls.Add(this.txtImportDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWarrantyPeriod);
            this.Controls.Add(this.label1);
            this.Name = "frmNewInstrument";
            this.Text = "New Instrument";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtWarrantyPeriod, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtImportDate, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWarrantyPeriod;
        private System.Windows.Forms.TextBox txtImportDate;
        private System.Windows.Forms.Label label7;
    }
}
