using System;
using System.Collections.Generic;
using V2_myPrivateFinance.Models;

namespace V2_myPrivateFinance.Views
{
    public partial class StatisticsForm : BaseForm
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

            List<Chart> chart = new List<Chart>()
                {GetPillarAtMonthYear(first), GetPillarAtMonthYear(second), GetPillarAtMonthYear(current)};
            chartPayments.DataSource = chart;
            chartPayments.Series["Income"].YValueMembers = "TotalIncome";
            chartPayments.Series["Expense"].YValueMembers = "TotalExpense";
            chartPayments.Series["Income"].XValueMember = "Month";
        }

        public Chart GetPillarAtMonthYear(DateTime dt)
        {
            Chart chart = new Chart();
            DataAccess.GetPaymentsByMothYear(dt).ForEach(p =>
                {
                    _ = p.IsIncome ? chart.TotalIncome += p.Amount : chart.TotalExpense += p.Amount;
                });
            chart.Month = dt.ToString("MMMM");
            return chart;
        }
    }
}
