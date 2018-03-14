using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
namespace Finance
{
    public partial class frm_main : Form
    {
        int income;
        int expense;
        int balance;
        int totalBalance;
        //DBConnection conn;

        public frm_main()
        {
            InitializeComponent();

            //dashboard tab
            income = Form_Methods.getSum("Assets", "income");
            expense = Form_Methods.getSum("Assets", "expense");
            balance = income - expense;
            label27.Text = balance.ToString();
            income = Form_Methods.getSum("Bank", "income");
            expense = Form_Methods.getSum("Bank", "expense");
            balance = income - expense;
            label26.Text = balance.ToString();
            totalBalance = Int32.Parse(label27.Text)+ Int32.Parse(label26.Text);
            lbl_sum_main.Text = totalBalance.ToString();


            //details tab
            Form_Methods.getMonth(cmb_month);
            Form_Methods.GetAccounts(cmb_account);
            Form_Methods.getYear(cmb_year);


        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            tab_main.SelectedTab = tab_dash;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            tab_main.SelectedTab = tab_new;
        }

        private void btn_details_Click(object sender, EventArgs e)
        {
            tab_main.SelectedTab = tab_details;
            

        }

        private void btn_add_addData_Click(object sender, EventArgs e)
        {
            
            try
            {
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt_add_date.Value.Month);
                string year = dt_add_date.Value.Year.ToString();
                int amt = Int32.Parse(txt_add_amt.Text);
                Form_Methods.AddNewEntry(cmb_add_account.Text, cmb_add_type.Text,amt , dt_add_date.Text, month, year, txt_add_details.Text);
                MessageBox.Show("Added");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Form_Methods.close_connection();
            }
         
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            Form_Methods.GetDataFilteredIncome(grid_income, cmb_account.Text, cmb_month.Text, cmb_year.Text);
            Form_Methods.GetDataFilteredExpense(grid_expense, cmb_account.Text, cmb_month.Text, cmb_year.Text);
            int expense = Form_Methods.GetDataFilteredExpenseSum(cmb_account.Text, cmb_month.Text, cmb_year.Text);
            int income = Form_Methods.GetDataFilteredIncomeSum(cmb_account.Text, cmb_month.Text, cmb_year.Text);
            int balance = income - expense;
            lbl_sum_income.Text = income.ToString();
            lbl_sum_expense.Text = expense.ToString();
            txt_sum2.Text = balance.ToString();
        }
    }
}
