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
    public partial class AlgoMedics : Form
    {

        string ConnectionString = "Server = 31.147.204.119; " + "Database = TeamE5_DB; " + "uid = TeamE5_User; " + "pwd = 9Gz_+GX8";

        private static AlgoMedics _instance;

        public static AlgoMedics Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AlgoMedics();
                return _instance;

            }
        }

        private void ShowForm(Form frm)
        {
            frm.Show();
            frm.Activate();
            this.Hide();
        }

        public AlgoMedics()
        {
            InitializeComponent();
            FillSymptoms();

        }


        void FillSymptoms()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string Query = "select condition from [TeamE5_DB].[dbo].[Drugs] GROUP  BY condition HAVING COUNT(*) > 1 ORDER BY condition ASC, COUNT(*) ASC ";
                SqlCommand all_drugs = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = all_drugs.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string Symptom_name = myReader["condition"].ToString();
                    comboBox1.Items.Add(Symptom_name);
                }

                sqlCon.Close();


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = comboBox1.Text;
            MessageBox.Show(s);

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {

                string Query = "select * from [TeamE5_DB].[dbo].[Drugs] where condition='" + s + "' ORDER BY drugName, (CASE when rating= '10.0' THEN '9.0' when rating = '9.0' THEN '8.0' when rating = '8.0' THEN '7.0' when rating = '7.0' THEN '6.0' when rating = '6.0' THEN '5.0' when rating = '5.0' THEN '4.0' when rating = '4.0' THEN '3.0' when rating = '3.0' THEN '2.0' when rating = '2.0' THEN '1.0' when rating = '1.0' THEN '' END ) DESC ";

                SqlCommand allowed_drugs = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = allowed_drugs.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string Symptom_name =" | " + myReader["Id"].ToString() + " | " + myReader["drugName"].ToString() +  " | " + myReader["rating"].ToString();
                    listBox1.Items.Add(Symptom_name);
                }

                sqlCon.Close();


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AlgoMedics_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

    }

}