using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindingList<Payment> n = DataAccess.GetPayments();
        }
    }
}
