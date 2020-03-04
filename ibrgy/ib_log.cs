using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ibrgy
{
    public partial class ib_log : Form
    {
        public ib_log()
        {
            InitializeComponent();
            this.ActiveControl = log_uname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Kei D. Penaredondo\source\repos\ibrgy\db_ibrgy.mdf;Integrated Security=True;Connect Timeout=30C: \Users\Kei D.Penaredondo\source\repos\ibrgy\db_ibrgy.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from emp_data Where emp_uname = '" + log_uname.Text.Trim() + "' and emp_pass = '" + log_pass.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if(dtbl.Rows.Count == 1)
            {
                ib_home ibh = new ib_home();
                this.Hide();
                ibh.Show();
            }
            else
            {
                MessageBox.Show("WRONG!!!");
            }
        }

        private void log_uname_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void log_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ib_log_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
