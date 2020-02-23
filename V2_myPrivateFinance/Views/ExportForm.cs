using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance.Views
{
    public partial class ExportForm : BaseForm
    {
        public ExportForm()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;
            if (!string.IsNullOrWhiteSpace(path) && Directory.Exists(path))
            {
                try
                {
                    List<Payment> payments = DataAccess.GetPayments();
                    StreamWriter sw = new StreamWriter(path + "/ExportData.csv");
                    sw.WriteLine("sep=,");
                    sw.WriteLine("Id, Category, Description, Date, Amount");
                    payments.ForEach(p => sw.WriteLine(p.Export()));
                    sw.Close();
                    MessageBox.Show("Successfully created/updated");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
