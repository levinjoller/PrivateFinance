using System;
using System.Windows.Forms;

namespace V2_myPrivateFinance.Views
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["AboutForm"] == null)
            {
                AboutForm af = new AboutForm();
                af.ShowDialog();
            }
        }

        private void manageCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ManageCategory"] == null)
            {
                ManageCategoy mc = new ManageCategoy();
                mc.ShowDialog();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["ExportForm"] == null)
            {
                ExportForm ef = new ExportForm();
                ef.ShowDialog();
            }
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["StatisticsForm"] == null)
            {
                StatisticsForm st = new StatisticsForm();
                st.ShowDialog();
            }
        }
    }
}
