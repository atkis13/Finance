using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Finance
{
    class Form_Methods
    {
        static DBConnection conn;

        public static void GetAccountDetailsFromDB()
        {
           

        }

        public static void GetDataFiltered()
        {

        }

        public static void AddNewEntry(string acc_name, string acc_type, int amt, string date, string month, string year, string details)
        {
            string query = "INSERT INTO details(account_name, type, amount, date, month, year, description) VALUES(@name, @type, @amt, @date, @month, @year, @dtls);";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@name", acc_name);
            cmd.Parameters.AddWithValue("@type", acc_type);
            cmd.Parameters.AddWithValue("@amt", amt);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@dtls", details);           
            cmd.ExecuteNonQuery();

        }

        public static void AddNewAccount()
        {

        }

        public static void close_connection()
        {
            conn.Close();
        }

        public static void CalculateBalance()
        {

        }

        public static void CreatePDFLog()
        {

        }

        public static void AddLog()
        {

        }

        
    }
}
