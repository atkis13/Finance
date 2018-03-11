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
        public frm_main()
        {
            InitializeComponent();
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
    }
}
