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


        public AlgoMedics()
        {
            InitializeComponent();
            FillSymptoms();

        }


        void FillSymptoms()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string Query = "select condition from [TeamE5_DB].[dbo].[Drugs2] GROUP  BY condition HAVING COUNT(*) > 1 ORDER BY condition ASC, COUNT(*) ASC ";
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

                


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String s = comboBox1.Text;
            //MessageBox.Show(s);

            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {

                string Query = "select * from [TeamE5_DB].[dbo].[Drugs2] where condition='" + s + "' ORDER BY drugName, (CASE when rating= '10.0' THEN '9.0' when rating = '9.0' THEN '8.0' when rating = '8.0' THEN '7.0' when rating = '7.0' THEN '6.0' when rating = '6.0' THEN '5.0' when rating = '5.0' THEN '4.0' when rating = '4.0' THEN '3.0' when rating = '3.0' THEN '2.0' when rating = '2.0' THEN '1.0' when rating = '1.0' THEN '' END ) DESC ";

                SqlCommand allowed_drugs = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = allowed_drugs.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string Symptom_name =" | " + myReader["Id"].ToString() + " |" + myReader["drugName"].ToString() +  "| " + myReader["rating"].ToString();
                    listBox1.Items.Add(Symptom_name);
                }

                sqlCon.Close();


            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                bool isAllergic = false; 

                sqlCon.Open();

                //MessageBox.Show(comboBox1.Text);
                string whole_string = listBox1.SelectedItem.ToString();
                string[] drug_selected =  whole_string.Split('|') ; //we use regex to get the 2nd string btw | | | 

                string Query0 = "select count(*) from [TeamE5_DB].[dbo].[Allergies] where id_medic='" + drug_selected[2] + "'";
                SqlCommand checkAllergic= new SqlCommand(Query0, sqlCon);
                var result = checkAllergic.ExecuteScalar();

                isAllergic = (int)checkAllergic.ExecuteScalar() > 0;

                if (isAllergic) 
                {
                    MessageBox.Show("WARNING ! : YOU ARE ALLERGIC TO " + drug_selected[2] + "!");
                }
                else
                {

                    MessageBox.Show(isAllergic.ToString());
                    MessageBox.Show(drug_selected[2]);
                    string Query = "INSERT INTO List_Medic(id_user,id_drug) VALUES (@val1, @val2)";

                    SqlCommand add_drug = new SqlCommand(Query, sqlCon);





                    add_drug.Parameters.AddWithValue("@val1", Connexion.User_id);
                    add_drug.Parameters.AddWithValue("@val2", drug_selected[2]);


                    add_drug.ExecuteNonQuery();
                }

                

                sqlCon.Close();


            }
        }
    }

}