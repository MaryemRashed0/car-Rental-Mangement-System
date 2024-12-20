using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace carrentalMangementSystem
{
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\plus\OneDrive\Documents\car.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        private void populate()
        {
            conn.Open();
            string query = "select * from RentalTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            RentDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void populate1()
        {
            conn.Open();
            string query = "select * from ReturnTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            ReturnedDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void Deleteonereturn()
        {
            int rentid;
            rentid = Convert.ToInt32(RentDGV.SelectedRows[0].Cells[0].Value.ToString());
            conn.Open();
            string query = "delete from RentalTbl where RentId =" + rentid + ";";
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
            conn.Close();
            populate();
            
        }
        private void Return_Load(object sender, EventArgs e)
        {
            populate();
            populate1();
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Carid.Text = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            Fnamee.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            Returndate.Text = RentDGV.SelectedRows[0].Cells[4].Value.ToString();
           


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form3 = new Main();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (id.Text == "" || Fnamee.Text == "" || Fine.Text == "" || Delay.Text == "")
            {
                MessageBox.Show("All information is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into ReturnTbl values (" + id.Text + ",'" +Carid.Text+ "','" + Fnamee.Text + "' ,'" + Returndate.Text + "','" + Fine.Text + "' )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car Dully Returned");
                    conn.Close();
                    populate1();
                    Deleteonereturn();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
