using System;
using System.Collections.Generic;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;
using V2_myPrivateFinance.Views;

namespace V2_myPrivateFinance
{
    public partial class Payments : BaseForm
    {
        List<Payment> payments = new List<Payment>();
        public Payments()
        {
            InitializeComponent();
            try
            {
                RefreshBindings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshBindings()
        {
            dataGridView1.DataSource = null;
            payments = DataAccess.GetPayments();
            dataGridView1.DataSource = payments;
            dataGridView1.Columns[2].DefaultCellStyle.Format = "yy-MM-dd";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "F2";
            dataGridView1.Columns[4].DisplayIndex = 1;
            label1.Text = "Balance: " + DataAccess.GetPaymentSum().ToString("F2");
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < payments.Count; i++)
            {
                if (!payments[i].IsIncome)
                {
                    dataGridView1.Rows[i].Cells["Amount"].Style.Format = "-0.00";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManagePaymentForm mpf = new ManagePaymentForm();
            if (mpf.ShowDialog() == DialogResult.OK)
            {
                RefreshBindings();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int i = dataGridView1.SelectedRows[0].Index;
                ManagePaymentForm mpf = new ManagePaymentForm(payments[i]);
                if (mpf.ShowDialog() == DialogResult.OK)
                {
                    RefreshBindings();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Payment payment = payments[dataGridView1.SelectedRows[0].Index];
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    DataAccess.DeletePayment(payment);
                    RefreshBindings();
                }
            }
        }
    }
}
