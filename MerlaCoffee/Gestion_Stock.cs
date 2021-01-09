using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace MerlaCoffee
{
    public partial class Gestion_Stock : Form
    {
        public Gestion_Stock()
        {
            InitializeComponent();
        }

        readonly MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select * from merlacoffee.user where username='" + username + "' and password='" + password + "'  ";
            try
            {
                MySqlDataReader readerr = cmd.ExecuteReader();
                if (readerr.Read())
                {
                    MessageBox.Show("bienvenue admin !!");
                    Admin a = new Admin();
                    a.Show();
                }
                else { MessageBox.Show("Erreur Username ou Password !!"); }
            }
            catch (MySqlException ms)
            {
                MessageBox.Show(ms.Message);
            }
            connection.Close();

        }

        private void Gestion_Stock_Load(object sender, EventArgs e)
        {

        }


    }
}
