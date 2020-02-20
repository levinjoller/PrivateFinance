namespace V2_myPrivateFinance.Views
{
    partial class ManagePaymentForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.nbrAmount = new System.Windows.Forms.NumericUpDown();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnIncome = new System.Windows.Forms.Button();
            this.btnExense = new System.Windows.Forms.Button();
            this.erp = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(91, 38);
            this.pictureBox1.Validating += new System.ComponentModel.CancelEventHandler(this.pictureBox1_Validating);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(229, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 22);
            this.textBox1.TabIndex = 2;
            this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // nbrAmount
            // 
            this.nbrAmount.DecimalPlaces = 2;
            this.nbrAmount.Location = new System.Drawing.Point(229, 163);
            this.nbrAmount.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nbrAmount.Name = "nbrAmount";
            this.nbrAmount.Size = new System.Drawing.Size(210, 22);
            this.nbrAmount.TabIndex = 3;
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(211, 249);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(228, 22);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Value = new System.DateTime(2020, 2, 20, 11, 31, 10, 0);
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(229, 204);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(210, 24);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCategory_Validating);
            // 
            // btnIncome
            // 
            this.btnIncome.Location = new System.Drawing.Point(110, 304);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(75, 23);
            this.btnIncome.TabIndex = 6;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            this.btnIncome.Click += new System.EventHandler(this.btnIncome_Click);
            // 
            // btnExense
            // 
            this.btnExense.Location = new System.Drawing.Point(295, 304);
            this.btnExense.Name = "btnExense";
            this.btnExense.Size = new System.Drawing.Size(75, 23);
            this.btnExense.TabIndex = 6;
            this.btnExense.Text = "Expense";
            this.btnExense.UseVisualStyleBackColor = true;
            this.btnExense.Click += new System.EventHandler(this.btnExense_Click);
            // 
            // erp
            // 
            this.erp.ContainerControl = this;
            // 
            // ManagePaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(519, 391);
            this.Controls.Add(this.btnExense);
            this.Controls.Add(this.btnIncome);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.nbrAmount);
            this.Controls.Add(this.textBox1);
            this.Name = "ManagePaymentForm";
            this.Text = "Manage Payment";
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.nbrAmount, 0);
            this.Controls.SetChildIndex(this.dtpDate, 0);
            this.Controls.SetChildIndex(this.cmbCategory, 0);
            this.Controls.SetChildIndex(this.btnIncome, 0);
            this.Controls.SetChildIndex(this.btnExense, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbrAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.NumericUpDown nbrAmount;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnExense;
        private System.Windows.Forms.ErrorProvider erp;
    }
}
