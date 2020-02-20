using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance.Views
{
    public partial class ManageCategoy : V2_myPrivateFinance.Views.BaseForm
    {
        BindingList<Category> categories = new BindingList<Category>();
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
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && new List<Category>(categories).Find(c => c.Name == textBox1.Text) == null)
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
                List<Payment> payments =  new List<Payment>(DataAccess.GetPayments());
                if (!payments.Exists(p => p.Category.Id == ((Category)lbCategories.SelectedItem).Id))
                {
                    DataAccess.DeleteCategory((Category)lbCategories.SelectedItem);
                    RefreshBindings();
                }
                else
                {
                    MessageBox.Show("Can't delete used Category");
                }
            }
            else
            {
                MessageBox.Show("No Category selected");
            }
        }
    }
}
