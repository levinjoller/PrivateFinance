using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance.Views
{
    public partial class ManagePaymentForm : BaseForm
    {
        List<Category> categories = new List<Category>();
        Payment payment = new Payment();

        public ManagePaymentForm()
        {
            InitializeComponent();
            FillCmbCategoryAndDate();
        }

        public ManagePaymentForm(Payment p)
        {
            payment = p;
            InitializeComponent();
            FillCmbCategoryAndDate();
            FillDialog();
        }

        private void FillDialog()
        {
            textBox1.Text = payment.Description;
            nbrAmount.Value = Convert.ToDecimal(payment.Amount);
            dtpDate.Value = payment.Date;
            cmbCategory.SelectedIndex = cmbCategory.FindStringExact(payment.Category.Name);
        }

        public void FillCmbCategoryAndDate()
        {
            dtpDate.Value = DateTime.Now;
            categories = DataAccess.GetCategories();
            foreach (Category c in categories)
            {
                cmbCategory.Items.Add(c);
            }
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            SubmitForm(true);
        }


        private void btnExense_Click(object sender, EventArgs e)
        {
            SubmitForm(false);
        }

        private void SubmitForm(bool isIncome)
        {
            if (ValidateChildren(ValidationConstraints.ImmediateChildren))
            {
                if (!IsPaymentsumGetNegative(isIncome))
                {
                    payment.Description = textBox1.Text;
                    payment.Amount = Math.Round(Convert.ToDouble(nbrAmount.Value) * 20) / 20;
                    payment.Category = (Category) cmbCategory.SelectedItem;
                    payment.Date = dtpDate.Value.Date;
                    payment.IsIncome = isIncome;
                    if (payment.Id == 0)
                    {
                        DataAccess.AddPayment(payment);
                    }
                    else
                    {
                        DataAccess.UpdatePayment(payment);
                    }
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Balance can't get under 0");
                }
            }
        }

        private bool IsPaymentsumGetNegative(bool isIncome)
        {
            if (isIncome || (DataAccess.GetPaymentSum() - Convert.ToDouble(nbrAmount.Value)) >= 0)
            {
                return false;
            }
            return true;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                erp.SetError(textBox1, "Value can't be null");
            }
            else
            {
                erp.SetError(textBox1, null);
            }
        }

        private void pictureBox1_Validating(object sender, CancelEventArgs e)
        {
            if (nbrAmount.Value <= 0)
            {
                e.Cancel = true;
                erp.SetError(nbrAmount, "Value can't be under 1");
            }
            else
            {
                erp.SetError(nbrAmount, null);
            }
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCategory.SelectedIndex < 0)
            {
                e.Cancel = true;
                erp.SetError(cmbCategory, "Must have value");
            }
            else
            {
                erp.SetError(cmbCategory, null);
            }
        }
    }
}
