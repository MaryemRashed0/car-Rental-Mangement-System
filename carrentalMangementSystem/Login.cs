using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carrentalMangementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\plus\OneDrive\Documents\car.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void label6_Click(object sender, EventArgs e)
        {
            Uname.Text = "";
            password.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string qurey = "select count (*) from UserTbl where Uname='" +Uname.Text+ "' and Upass='" +password.Text+ "' ";
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(qurey, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            conn.Close();
        }
    }
}
