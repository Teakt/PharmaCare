﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhramaCare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "server=31.147.204.119\PISERVER,1433;database=TeamE5_DB;uid=TeamE5_User;pwd=9Gz_+GX8";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("server=31.147.204.119\PISERVER,1433;database=TeamE5_DB;uid=TeamE5_User;pwd=9Gz_+GX8");
            sql.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Nice try");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("L2");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "server=31.147.204.119\PISERVER,1433;database=TeamE5_DB;uid=TeamE5_User;pwd=9Gz_+GX8";
            sql.Open();
            string userid = textBox1.Text;
            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select userid,password from users where userid='" + textBox1.Text + "'and password'" + textBox2.Text + "'", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login success");
                //System.Diagnostics.Process.Start();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
