using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Data;

namespace Finance
{
    class Form_Methods
    {
        static DBConnection conn;
        
       
       

        public static void GetAccountDetailsFromDB()
        {
           

        }

        public static void GetDataFilteredIncome(DataGridView dw, string account, string month, string year)
        {
            string query = "Select * from  details where type = @income AND account_name = @account And month = @month AND year = @year;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@account", account);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@income", "income");
            MySqlDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = cmd;
            DataTable db = new DataTable();
            adap.Fill(db);
            BindingSource bsourc = new BindingSource();
            bsourc.DataSource = db;
            dw.DataSource = bsourc;
            adap.Update(db);

        }
        public static int GetDataFilteredIncomeSum(string account, string month, string year)
        {
            int sum = 0;
            string query = "Select * from  details where type = @income AND account_name = @account And month = @month AND year = @year;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@account", account);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@income", "income");
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                sum += red.GetInt32("amount");

            }
            return sum;


        }

        public static void GetDataFilteredExpense(DataGridView dw, string account, string month, string year)
        {
            string query = "Select * from  details where type = @expense AND account_name = @account And month = @month AND year = @year;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@account", account);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@expense", "expense");
            MySqlDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = cmd;
            DataTable db = new DataTable();
            adap.Fill(db);
            BindingSource bsourc = new BindingSource();
            bsourc.DataSource = db;
            dw.DataSource = bsourc;
            adap.Update(db);
        }
        public static int GetDataFilteredExpenseSum(string account, string month, string year)
        {
            int sum = 0;
            string query = "Select * from  details where type = @expense AND account_name = @account And month = @month AND year = @year;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@account", account);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            cmd.Parameters.AddWithValue("@expense", "expense");
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                sum += red.GetInt32("amount");

            }
            return sum;
        }

            public static void getMonth(ComboBox cb)
        {
            string query = "Select distinct month from details;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string acc_ = red.GetString("month");
                cb.Items.Add(acc_);
            }

        }

        public static void getYear(ComboBox cb)
        {
            string query = "Select distinct year from details;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string acc_ = red.GetString("year");
                cb.Items.Add(acc_);
            }

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

        public static void GetAccounts(ComboBox cb)
        {
            string query = "Select * from accounts;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());           
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {
                string acc_ = red.GetString("account_name");
                cb.Items.Add(acc_);
            }

        }

        public static void close_connection()
        {
            conn.Close();
        }

        public static int getSum(string account, string type)
        {
            int sum = 0;
            string query = "Select * from details WHERE account_name=@account AND type=@type;";
            conn = new DBConnection();
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(query, conn.getConnection());
            cmd.Parameters.AddWithValue("@account",account);
            cmd.Parameters.AddWithValue("@type", type);
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read())
            {                
                    sum += red.GetInt32("amount");                   
                
            }
            return sum;

        }

        
        public static int CalculateBalance(int income, int expense)
        {
            return income - expense;
        }

        public static void CreatePDFLog()
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Log.pdf", FileMode.Create));
            doc.Open();
            DateTime d = DateTime.Now;
            Paragraph p0 = new Paragraph(d.ToString() + ": Log Created");
            Paragraph p12 = new Paragraph(" ");
            Paragraph p13 = new Paragraph("=================================================");
            Paragraph p14 = new Paragraph(" ");
            Paragraph p15 = new Paragraph(" ");
            doc.Add(p0);
            doc.Add(p12);
            doc.Add(p13);
            doc.Add(p14);
            doc.Add(p15);
            doc.Close();

        }

        public static void AddLog(string previous, string current)
        {
            DateTime d = DateTime.Now;
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("Log.pdf", FileMode.Create));
            doc.Open();
            Paragraph p0 = new Paragraph(previous);
            Paragraph p_date = new Paragraph(d.ToString() + ":");
            Paragraph p1 = new Paragraph(current);
            Paragraph p12 = new Paragraph(" ");
            Paragraph p13 = new Paragraph("=================================================");
            Paragraph p14 = new Paragraph(" ");
            Paragraph p15 = new Paragraph(" ");
            doc.Add(p0);
            doc.Add(p_date);
            doc.Add(p1);
            doc.Add(p12);
            doc.Add(p13);
            doc.Add(p14);
            doc.Add(p15);
            doc.Close();
        }

        public static void ReadLog(RichTextBox rt)
        {
            string strx = string.Empty;

            try
            {
                //adding the pdf to the rich text box
                PdfReader reader = new PdfReader("Log.pdf");
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.LocationTextExtractionStrategy();
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    strx = strx + s;
                    rt.Text = strx;
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
    }
}
