using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace carrentalMangementSystem
{
    public partial class Cars : Form
    {
        public Cars()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\plus\OneDrive\Documents\car.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False");
       

        private void populate()
        {
            conn.Open();
            string query = "select * from CarTbl";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDGV.DataSource = ds.Tables[0];
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (RegNo.Text == "" || Brand.Text == "" || Model.Text == "" || Price.Text == "")
            {
                MessageBox.Show("All information is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into CarTbl values (" + RegNo.Text + ",'" + Brand.Text + "','" + Model.Text + "' , '"+Available.SelectedItem.ToString()+ "','" + Price.Text + "' )";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car successfully Added");
                    conn.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            populate();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (RegNo.Text == "")
            {
                MessageBox.Show("RegNum is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from CarTbl where RegNum =" + RegNo.Text + ";";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Car deleted successfully");
                    conn.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void CarsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RegNo.Text = CarsDGV.SelectedRows[0].Cells[0].Value.ToString();
            Brand.Text = CarsDGV.SelectedRows[0].Cells[1].Value.ToString();
            Model.Text = CarsDGV.SelectedRows[0].Cells[2].Value.ToString();
            Price.Text = CarsDGV.SelectedRows[0].Cells[3].Value.ToString();
            Available.SelectedItem = CarsDGV.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (RegNo.Text == "" || Brand.Text == "" || Model.Text == "" || Price.Text == "")
            {
                MessageBox.Show("All information is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "update CarTbl set Model = '" + Model.Text + "',Brand = '" + Brand.Text + "',Price = '" + Price.Text + "',Avaliable = '" + Available.SelectedItem + "'where RegNum =" + RegNo.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car successfully updated");
                    conn.Close();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main form3 = new Main();
            form3.Show();
        }


        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Search_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string flag = "";
            if(Search.SelectedItem.ToString() == "Available") 
            {
                flag = "Yes";
            }
            else
            {
                flag = "No";
            }
            conn.Open();
            string query = "select * from CarTbl where Avaliable = '"+flag+"'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            CarsDGV.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
