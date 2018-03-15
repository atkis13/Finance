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
            dashRefresh();
            try
            {
                Form_Methods.ReadLog(rt_log);
                Form_Methods.GetAccounts(cmb_add_account);
                cmb_add_type.Items.Add("income");
                cmb_add_type.Items.Add("expense");
                Form_Methods.getMonth(cmb_month);
                Form_Methods.GetAccounts(cmb_account);
                Form_Methods.getYear(cmb_year);
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

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            tab_main.SelectedTab = tab_dash;
            dashRefresh();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            tab_main.SelectedTab = tab_new;
           
        }

        private void btn_details_Click(object sender, EventArgs e)
        {
            tab_main.SelectedTab = tab_details;
            


        }

        public void dashRefresh()
        {
            try
            {
                //dashboard tab
                income = Form_Methods.getSum("Assets", "income");
                expense = Form_Methods.getSum("Assets", "expense");
                balance = income - expense;
                label27.Text = balance.ToString();

                income = Form_Methods.getSum("Bank", "income");
                expense = Form_Methods.getSum("Bank", "expense");
                balance = income - expense;
                label26.Text = balance.ToString();

                income = Form_Methods.getSum("LTSS", "income");
                expense = Form_Methods.getSum("LTSS", "expense");
                balance = income - expense;
                label25.Text = balance.ToString();

                income = Form_Methods.getSum("Cheltuieli", "income");
                expense = Form_Methods.getSum("Cheltuieli", "expense");
                balance = income - expense;
                label24.Text = balance.ToString();

                income = Form_Methods.getSum("Educatie", "income");
                expense = Form_Methods.getSum("Educatie", "expense");
                balance = income - expense;
                label23.Text = balance.ToString();

                income = Form_Methods.getSum("Fun", "income");
                expense = Form_Methods.getSum("Fun", "expense");
                balance = income - expense;
                label22.Text = balance.ToString();

                income = Form_Methods.getSum("Donatii", "income");
                expense = Form_Methods.getSum("Donatii", "expense");
                balance = income - expense;
                label21.Text = balance.ToString();

                income = Form_Methods.getSum("Penny", "income");
                expense = Form_Methods.getSum("Penny", "expense");
                balance = income - expense;
                label12.Text = balance.ToString();

                income = Form_Methods.getSum("XRP", "income");
                expense = Form_Methods.getSum("XRP", "expense");
                balance = income - expense;
                label20.Text = balance.ToString();

                income = Form_Methods.getSum("ETN", "income");
                expense = Form_Methods.getSum("ETN", "expense");
                balance = income - expense;
                label19.Text = balance.ToString();

                income = Form_Methods.getSum("Wedding", "income");
                expense = Form_Methods.getSum("Wedding", "expense");
                balance = income - expense;
                label18.Text = balance.ToString();

                income = Form_Methods.getSum("Travel", "income");
                expense = Form_Methods.getSum("Travel", "expense");
                balance = income - expense;
                label17.Text = balance.ToString();

                income = Form_Methods.getSum("BCR Bonds", "income");
                expense = Form_Methods.getSum("BCR Bonds", "expense");
                balance = income - expense;
                label39.Text = balance.ToString();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            


            totalBalance = Int32.Parse(label27.Text) + Int32.Parse(label26.Text) + Int32.Parse(label25.Text) + Int32.Parse(label24.Text) + Int32.Parse(label23.Text) + Int32.Parse(label22.Text) + Int32.Parse(label21.Text)+ Int32.Parse(label12.Text) + Int32.Parse(label20.Text) + Int32.Parse(label19.Text) + Int32.Parse(label18.Text) + Int32.Parse(label17.Text)+ Int32.Parse(label39.Text);
            lbl_sum_main.Text = totalBalance.ToString();
        }

        private void btn_add_addData_Click(object sender, EventArgs e)
        {
            
            try
            {
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dt_add_date.Value.Month);
                string year = dt_add_date.Value.Year.ToString();
                int amt = Int32.Parse(txt_add_amt.Text);
                Form_Methods.AddNewEntry(cmb_add_account.Text, cmb_add_type.Text,amt , dt_add_date.Text, month, year, txt_add_details.Text);
                string message_2 = "Added "+amt + " as " + cmb_add_type.Text + " to " + cmb_add_account.Text;
                MessageBox.Show(message_2);
                Form_Methods.AddLog(rt_log.Text, message_2);
                Form_Methods.ReadLog(rt_log);
                cmb_add_account.Text = "";
                cmb_add_type.Text = "";
                txt_add_amt.Text = "";
                dt_add_date.Text = "";
                txt_add_details.Text = "";
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
           
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Form_Methods.close_connection();
            }
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            try
            {
                Form_Methods.CreatePDFLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        
    }
}
