using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
