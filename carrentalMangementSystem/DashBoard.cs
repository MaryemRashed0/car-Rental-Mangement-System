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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\plus\OneDrive\Documents\car.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void DashBoard_Load(object sender, EventArgs e)
        {
            string querycar = "select Count(*) from CarTbl";
            SqlDataAdapter sda = new SqlDataAdapter(querycar, conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label5.Text = dt.Rows[0][0].ToString();

            string querycust = "select Count(*) from customerTbl";
            SqlDataAdapter sda1 = new SqlDataAdapter(querycust, conn);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            label6.Text = dt1.Rows[0][0].ToString();

            string queryuser = "select Count(*) from UserTbl";
            SqlDataAdapter sda2 = new SqlDataAdapter(queryuser, conn);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            label8.Text = dt2.Rows[0][0].ToString();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form3 = new Main();
            form3.Show();
        }
    }
}
