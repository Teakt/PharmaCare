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
    public partial class UserProfil : Form
    {

        string ConnectionString = "Server = 31.147.204.119; " + "Database = TeamE5_DB; " + "uid = TeamE5_User; " + "pwd = 9Gz_+GX8";

        public UserProfil()
        {
            InitializeComponent();
            DisplayProfil();
            FillDrugs();
            FillAllergies();
            DisplayDrugs();
        }

        void DisplayProfil()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {

                string Query = "select * from [TeamE5_DB].[dbo].[Users] where user_id='" + Connexion.User_id + "'"; // ONLY THE CONNECTED USER S INFOS ARE DISPLAYED

                SqlCommand user_infos = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = user_infos.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string User_info = " LOGIN NAME : " + myReader["user_id"].ToString() + " \nNAME : " + myReader["name"].ToString() + " \nMAIL :| " + myReader["mail"].ToString() + " \nID NUMBER :| " + myReader["IDnumber"].ToString() + " \nPHONE NUMBER :| " + myReader["phonenumber"].ToString();
                    //listBox1.Items.Add(User_info);
                    richTextBox1.AppendText(User_info);
                }

                sqlCon.Close();



            }
        }

        void FillDrugs()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string Query = "select drugName from [TeamE5_DB].[dbo].[Drugs2] GROUP  BY drugName HAVING COUNT(*) > 1 ORDER BY drugName ASC, COUNT(*) ASC ";
                SqlCommand all_drugs = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = all_drugs.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string Drug_name = myReader["drugName"].ToString();
                    comboBox1.Items.Add(Drug_name);
                }




            }
        }

        void FillAllergies()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string Query = "select * from [TeamE5_DB].[dbo].[Allergies] where id_user='" + Connexion.User_id + "'";
                SqlCommand all_drugs = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = all_drugs.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string Drug_name = myReader["id_user"].ToString() + " | " + myReader["id_medic"].ToString();
                    listBox1.Items.Add(Drug_name);
                }




            }
        }

        void DisplayDrugs()
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {
                string Query = "select * from [TeamE5_DB].[dbo].[List_Medic] where id_user='" + Connexion.User_id + "'";
                SqlCommand all_drugs = new SqlCommand(Query, sqlCon);
                SqlDataReader myReader;

                sqlCon.Open();
                myReader = all_drugs.ExecuteReader();


                while (myReader.Read())
                {
                    //string column_index = myReader["condition"].ToString(); // SO WE GET THE INDeX OF COLUMN CONDITION WHICH IS OUR SYMPTOM
                    //int columnValue = Convert.ToInt32(myReader['condition']);
                    string Drug_name = myReader["id_user"].ToString() + " | " + myReader["id_drug"].ToString();
                    listBox2.Items.Add(Drug_name);
                }




            }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConnectionString))
            {

                sqlCon.Open();

                MessageBox.Show(comboBox1.Text);
                string allergy_selected = comboBox1.Text;
                string Query = "INSERT INTO Allergies(id_user,id_medic) VALUES (@val1, @val2)";

                SqlCommand add_allergy = new SqlCommand(Query, sqlCon);



               

                add_allergy.Parameters.AddWithValue("@val1", Connexion.User_id);
                add_allergy.Parameters.AddWithValue("@val2", allergy_selected);


                add_allergy.ExecuteNonQuery();
                listBox1.Items.Clear();
                FillAllergies();



            }
        }

        private void UserProfil_Load(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
