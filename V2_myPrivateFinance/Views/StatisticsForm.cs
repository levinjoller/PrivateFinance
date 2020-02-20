using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance.Views
{
    public partial class StatisticsForm : V2_myPrivateFinance.Views.BaseForm
    {
        public StatisticsForm()
        {
            InitializeComponent();
            FillChart();
        }

        public void FillChart()
        {
            DateTime first = DateTime.Now.AddMonths(-2);
            DateTime second = DateTime.Now.AddMonths(-1);
            DateTime current = DateTime.Now;

            BindingList<Chart> chart = new BindingList<Chart>()
                {GetPillarAtMonthYear(first), GetPillarAtMonthYear(second), GetPillarAtMonthYear(current)};
            chartPayments.DataSource = chart;
            chartPayments.Series["Income"].YValueMembers = "TotalIncome";
            chartPayments.Series["Expense"].YValueMembers = "TotalExpense";
            chartPayments.Series["Income"].XValueMember = "Month";
        }

        public Chart GetPillarAtMonthYear(DateTime dt)
        {
            Chart chart = new Chart();
            List<Payment> payments = new List<Payment>(DataAccess.GetPayments());
            payments.FindAll(p => p.Date.ToString("MM-yy") == dt.ToString("MM-yy")).ForEach(p =>
                {
                    _ = p.IsIncome ? chart.TotalIncome += p.Amount : chart.TotalExpense += p.Amount;
                });
            chart.Month = dt.ToString("MMMM");
            return chart;
        }
    }
}
