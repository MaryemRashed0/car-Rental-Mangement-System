﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace carrentalMangementSystem
{
    public partial class start : System.Windows.Forms.Form
    {
        public start()
        {
            InitializeComponent();
        }
        int startpoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            guna2CircleProgressBar1.Value = startpoint;
            label2.Text = "" + startpoint;
            if (guna2CircleProgressBar1.Value == 100)
            {
                guna2CircleProgressBar1.Value = 0;
                timer1.Stop();
                Login log = new Login();
                log.Show();
                this.Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
