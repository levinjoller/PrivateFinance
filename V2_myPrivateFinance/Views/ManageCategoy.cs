using System;
using System.Collections.Generic;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance.Views
{
    public partial class ManageCategoy : BaseForm
    {
        List<Category> categories = new List<Category>();
        public ManageCategoy()
        {
            InitializeComponent();
            RefreshBindings();
        }

        public void RefreshBindings()
        {
            lbCategories.DataSource = null;
            categories = DataAccess.GetCategories();
            lbCategories.DataSource = categories;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && categories.Find(c => c.Name == textBox1.Text) == null)
            {
                Category category = new Category()
                {
                    Name = textBox1.Text
                };
                DataAccess.AddCategory(category);
                RefreshBindings();
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (lbCategories.SelectedItem != null)
            {
                List<Payment> payments =  DataAccess.GetPayments();
                if (!payments.Exists(p => p.Category.Id == ((Category)lbCategories.SelectedItem).Id))
                {
                    DataAccess.DeleteCategory((Category)lbCategories.SelectedItem);
                    RefreshBindings();
                }
                else
                {
                    MessageBox.Show("Can't delete used category");
                }
            }
            else
            {
                MessageBox.Show("No category selected");
            }
        }
    }
}
