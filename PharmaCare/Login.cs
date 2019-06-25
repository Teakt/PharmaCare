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

namespace PhramaCare
{
    public partial class Form1 : Form
    {
        private static Form1 _instance;

        public static Form1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Form1();
                return _instance;

            }
        }

        private void ShowForm(Form frm)
        {
            frm.Show();
            frm.Activate();
            this.Hide();
        }

        public Form1()
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Server=31.147.204.119;"+"Database=TeamE5_DB;"+"uid=TeamE5_User;"+"pwd=9Gz_+GX8";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection("Server=31.147.204.119;" + "Database=TeamE5_DB;" + "uid=TeamE5_User;" + "pwd=9Gz_+GX8");
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Server = 31.147.204.119; "+"Database = TeamE5_DB; "+"uid = TeamE5_User; "+"pwd = 9Gz_+GX8";
            sql.Open();

            

            string userid = textBox1.Text;
            // HERE WE SET THE GLOBAL USER ID

            Connexion.User_id = userid;
            


            string password = textBox2.Text;
            SqlCommand cmd = new SqlCommand("select user_id,password from users where user_id='" + textBox1.Text + "'and password='" + textBox2.Text + "'", sql);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Login success");
                ShowForm(AlgoMedics.Instance);
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
            ShowForm(MDIContainer.Instance);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
    }
}
