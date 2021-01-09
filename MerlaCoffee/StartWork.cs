using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MerlaCoffee
{
    public partial class StartWork : Form
    {
        public StartWork()
        {
            InitializeComponent();
        }

        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");


        void DebutT(String a, String b)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO merlacoffee.duree_de_travaiL  (id_emp,date_d,date_f)  VALUES ((SELECT id from merlacoffee.caissier where CIN='" + b + "'),CURRENT_TIMESTAMP,null)";
                MySqlDataReader readerr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Communiquer avec l'Admin!! ");
            }
            connection.Close();
        }


        public static String nom = "";
        public static String CIN = "";

        private void button1_Click(object sender, EventArgs e)
        {

            nom = textBox1.Text;
            CIN = textBox2.Text;
            //L'enter d'admin
            if (nom == "admin" || CIN == "admin123")
            {
                Admin a = new Admin();
                a.Show();
            }
            else
            {
                //L'entrer de caissier
                DebutT(nom, CIN);
                connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * from merlacoffee.caissier where CIN='" + CIN + "' and date_fin is null";
                    MySqlDataReader readerr = cmd.ExecuteReader();
                    if (readerr.Read())
                    {
                        MessageBox.Show("Bienvenu " + nom);
                        Visible = false;
                        //new Home().Show();
                        Home h = new Home();
                        h.Show();
                    }
                    else
                    {
                        MessageBox.Show("Verifier votre nom ou CIN monsieur !!");
                    }
              
                connection.Close();
            }
        }

        private void StartWork_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void StartWork_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}
