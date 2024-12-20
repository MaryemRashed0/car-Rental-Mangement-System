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
    public partial class Rental : Form
    {
        public Rental()
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
        private void updateonRent()
        {
            conn.Open();
            string query = "update CarTbl set Avaliable = '" + "No" + "'where RegNum =" + Carreg.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Car successfully updated");
            conn.Close();
        }

        private void updateonRentDelete()
        {
            conn.Open();
            string query = "update CarTbl set Avaliable = '" + "Yes" + "'where RegNum =" + Carreg.SelectedValue.ToString() + ";";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Car successfully updated");
            conn.Close();
        }

        private void fillcombo()
        {
            conn.Open();
            string query = "select RegNum from CarTbl where Avaliable='" + "Yes" + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("RegNum", typeof(string));
            dt.Load(rdr);
            Carreg.ValueMember = "RegNum";
            Carreg.DataSource = dt;
            conn.Close();
        }
        private void fillCustomer()
        {
            conn.Open();
            string query = "select CusID from customerTbl";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CusID", typeof(int));
            dt.Load(rdr);
            CustId.ValueMember = "CusID";
            CustId.DataSource = dt;
            conn.Close();
        }
        private void fetchCustName()
        {
            conn.Open();
            string query = "select * from CustomerTbl where CusID =" + CustId.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Fnamee.Text = dr["CusName"].ToString();
            }
            conn.Close();
        }
        private void Address_Click(object sender, EventArgs e)
        {

        }

        private void Rental_Load(object sender, EventArgs e)
        {
            fillcombo();
            fillCustomer();
            populate();
        }

        private void Carreg_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void CustId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            fetchCustName();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (id.Text == "" || Fnamee.Text == "" || Fees.Text == "")
            {
                MessageBox.Show("All information is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "insert into RentalTbl values (" + id.Text + ",'" + Carreg.SelectedValue.ToString() + "','" + Fnamee.Text + "','" + Rentdate.Text + "' ,'" + Returndate.Text + "' , '" + Fees.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Car successfully Rented");
                    conn.Close();
                    updateonRent();
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("id is required");
            }
            else
            {
                try
                {
                    conn.Open();
                    string query = "delete from RentalTbl where RentId =" + id.Text + ";";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Rental deleted successfully");
                    conn.Close();
                    populate();
                    updateonRentDelete();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            id.Text = RentDGV.SelectedRows[0].Cells[0].Value.ToString();
            Carreg.SelectedValue = RentDGV.SelectedRows[0].Cells[1].Value.ToString();
            Fnamee.Text = RentDGV.SelectedRows[0].Cells[2].Value.ToString();
            Fees.Text = RentDGV.SelectedRows[0].Cells[5].Value.ToString();

        }
    } 
}
