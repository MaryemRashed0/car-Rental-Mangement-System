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

namespace carrentalMangementSystem
{
    public partial class Cust : Form
    {
        public Cust()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\plus\OneDrive\Documents\car.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        private void populate()
        {
            conn.Open();
            string query = "select * from customerTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CustomersDGV.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void CustomersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id.Text = CustomersDGV.SelectedRows[0].Cells[0].Value.ToString();
            Fnamee.Text = CustomersDGV.SelectedRows[0].Cells[1].Value.ToString();
            Adress.Text = CustomersDGV.SelectedRows[0].Cells[2].Value.ToString();
            Mphone.Text = CustomersDGV.SelectedRows[0].Cells[3].Value.ToString();
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form3 = new Main();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (id.Text == "" || Fnamee.Text == "" || Adress.Text == "" || Mphone.Text == "")
            {
                MessageBox.Show("All information is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into customerTbl values (" + id.Text + ",'" + Fnamee.Text + "','" + Adress.Text + "' ,'" + Mphone.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer successfully Added");
                    conn.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (id.Text == "" || Fnamee.Text == "" || Adress.Text == "" || Mphone.Text == "")
            {
                MessageBox.Show("All information is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update customerTbl set Phone = '" + Mphone.Text + "',CusName = '" + Fnamee.Text + "',CusAdd = '" + Adress.Text + "'where CusID =" + id.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer successfully updated");
                    conn.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

            if (id.Text == "")
            {
                MessageBox.Show("Cust id is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from customerTbl where CusID =" + id.Text + ";";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer deleted successfully");
                    conn.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Cust_Load(object sender, EventArgs e)
        {
            populate();
        }
    }
}