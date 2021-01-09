using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MerlaCoffee
{
    public partial class StockUpdate : Form
    {
        public StockUpdate()
        {
            InitializeComponent();
          
        }
      //MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
       
        private void button1_Click(object sender, EventArgs e)
        {
            String a = comboBox1.Text;
            int s = int.Parse(textBox.Text);
            MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Update merlacoffee.matiere_premiere set qte='"+s+ "' WHERE nommat='"+a+"' ";
            MySqlDataReader reader = cmd.ExecuteReader();
            MessageBox.Show("Stock Modifier !!");
            Admin ad = new Admin();
            //ad.showstock();
            connection.Close();
            }
        
        private void StockUpdate_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("---Select---");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
