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
    public partial class Register : Form
    {

        
        string ConnectionString = "Server = 31.147.204.119; "+"Database = TeamE5_DB; "+"uid = TeamE5_User; "+"pwd = 9Gz_+GX8";
        
       

        private static Register _instance;

        public static Register Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Register();
                return _instance;

            }
        }


        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {

            if (txtusername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please fill the Username and the Password !");
            }
            else if(txtPassword.Text != txtConfirmPasswd.Text)
            {
                MessageBox.Show("Passwords don't match !");
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
                {



                    sqlCon.Open();
                    //..
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@user_id", txtusername.Text.Trim()); // ALLOWS TO ADD USER ID ON DATABASE WEBDIIIP
                    sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@mail", txtMail.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@IDnumber", txtIDnumber.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@phonenumber", txtPhonenumber.Text.Trim());
                    sqlCmd.ExecuteNonQuery(); // Executes a Transact-SQL statement against the connection and returns the number of rows affected.

                    MessageBox.Show(" WELL PLAYED ! REGISTRATION SUCCESSFUL ! WELCOME TO PHARMACARE !");
                    Clear();
                }
            }

            
        }


        void Clear()
        {
            txtusername.Text = txtPhonenumber.Text = txtPassword.Text = txtName.Text = txtMail.Text = txtIDnumber.Text = txtConfirmPasswd.Text = "";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;

        }
    }
}
