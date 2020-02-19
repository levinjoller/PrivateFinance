using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace V2_myPrivateFinance.Models
{
    public static class DataAccess
    {
        static SqlConnection con;
        private static void OpenConnection()
        {
            try
            {
                string conString = "server=localhost;Database=privatefinance;Trusted_Connection=yes;";
                con = new SqlConnection(conString);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private static void CheckConnection()
        {
            if (con == null || con.State != System.Data.ConnectionState.Open)
            {
                OpenConnection();
            }
        }

        private static SqlDataReader GetDataReader(string query)
        {
            CheckConnection();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            return rdr;
        }

        public static BindingList<Category> GetCategories()
        {
            BindingList<Category> categories = new BindingList<Category>();
            SqlDataReader rdr = GetDataReader("SELECT * FROM Categories");
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Category c = new Category();
                    c.Id = rdr.GetInt32(0);
                    c.Name = rdr[1].ToString();
                    categories.Add(c);
                }
            }
            rdr.Close();
            return categories;
        }

        public static BindingList<Payment> GetPayments()
        {
            BindingList<Payment> payments = new BindingList<Payment>();
            List<Category> categories = new List<Category>(GetCategories());
            SqlDataReader rdr = GetDataReader("SELECT * FROM Payments");
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Payment p = new Payment();
                    p.Id = rdr.GetInt32(0);
                    p.Description = rdr[1].ToString();
                    p.Date = rdr.GetDateTime(2);
                    p.Amount = rdr.GetDouble(3);
                    p.IsIncome = rdr.GetBoolean(4);
                    p.Category = categories.Find(c => c.Id == rdr.GetInt32(5));
                    payments.Add(p);
                }
            }
            rdr.Close();
            return payments;
        }
    }
}
