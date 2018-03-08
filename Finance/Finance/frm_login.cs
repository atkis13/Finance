using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Finance
{
    public partial class frm_login : Form
    {
        DBConnection conn;
        public frm_login()
        {
            InitializeComponent();
        }

        private void txt_login_Click(object sender, EventArgs e)
        {
            string user = txt_user.Text;
            string pass = txt_pass.Text;

            try
            {
                conn = new DBConnection();
                if (user == conn.Username && pass == conn.Password)
                {
                    conn.Open();
                    this.Hide();
                    frm_main main = new frm_main();
                    main.Show();

                }

                else
                {
                    MessageBox.Show("Ivalid username or password");
                }



            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
        }
    }
    
}
