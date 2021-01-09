using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MerlaCoffee
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nom, prenom, CIN;
            nom = textBox1.Text; ;
            prenom = textBox2.Text;
            CIN = textBox3.Text;
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO merlacoffee.caissier (nom,prenom,CIN,date_debut,date_fin,id_chef) values('" + nom + "','" + prenom + "','" + CIN + "',CURRENT_TIMESTAMP,NULL,1)";
            MySqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("bienvenue Caissier !!");
            connection.Close();
            Admin ex = new Admin();
            ex.ShowDateCaisse();


        }
    }
}
