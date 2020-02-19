using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace V2_myPrivateFinance.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public bool IsIncome { get; set; }
        public Category Category { get; set; }
    }
}
