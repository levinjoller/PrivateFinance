using System;
using System.ComponentModel;

namespace V2_myPrivateFinance.Models
{
    public class Payment
    {
        [DisplayName("#")]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        [Browsable(false)]
        public bool IsIncome { get; set; }
        public Category Category { get; set; }

        public string Export()
        {
            string d = $"\"{Description.Replace("\"", "\"\"")}\"";
            string c = $"\"{Category.Name.Replace("\"", "\"\"")}\"";
            return $"{Id}, {c}, {d}, {Date.ToShortDateString()}, {(IsIncome ? Amount : Amount * -1).ToString("F2").Replace(",", ".")}";
        }
    }
}
