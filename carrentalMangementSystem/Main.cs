using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace carrentalMangementSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Cars cars = new Cars();
            cars.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cust Cust = new Cust();
            Cust.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rental Rental = new Rental();
            Rental.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return Return = new Return();
            Return.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
           Users users = new Users();
            users.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashBoard dashBoard = new DashBoard();
            dashBoard.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
