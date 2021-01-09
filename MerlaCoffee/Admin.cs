using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace MerlaCoffee
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");

         void showstock() {
            connection.Open();
            MySqlDataAdapter MyDA = new MySqlDataAdapter();
            string sqlSelectAll = "select * from merlacoffee.matiere_premiere";
            MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, connection);

            DataTable table = new DataTable();
            MyDA.Fill(table);

            BindingSource bSource = new BindingSource();
            bSource.DataSource = table;

            dataGridView1.DataSource = bSource;
            connection.Close();
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            showstock();
            ShowDate();
            ShowData();
            Showcmd();
        }

        public void ShowData()
        {

            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "select * from merlacoffee.caissier";
            MyDA2.SelectCommand = new MySqlCommand(sqlSelectAll2, connection);

            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);

            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = table2;


            dataGridView2.DataSource = bSource2;
            connection.Close();
        }
        public void Showcmd()
        {

            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "select * from merlacoffee.commande";
            MyDA2.SelectCommand = new MySqlCommand(sqlSelectAll2, connection);

            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);

            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = table2;


            dataGridView4.DataSource = bSource2;
            connection.Close();
        }
        public void ShowDate()
        {

            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "select * from merlacoffee.duree_de_travail";
            MyDA2.SelectCommand = new MySqlCommand(sqlSelectAll2, connection);

            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);

            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = table2;
            dataGridView3.DataSource = bSource2;
            connection.Close();
        }
        public void ShowDateCaisse()
        {

            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "select * from merlacoffee.caissier";
            MyDA2.SelectCommand = new MySqlCommand(sqlSelectAll2, connection);

            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);

            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = table2;
            dataGridView2.DataSource = bSource2;
            connection.Close();
        }
        public void ShowMP()
        {

            MySqlDataAdapter MyDA2 = new MySqlDataAdapter();
            string sqlSelectAll2 = "select * from merlacoffee.matiere_premiere";
            MyDA2.SelectCommand = new MySqlCommand(sqlSelectAll2, connection);

            DataTable table2 = new DataTable();
            MyDA2.Fill(table2);

            BindingSource bSource2 = new BindingSource();
            bSource2.DataSource = table2;
            dataGridView1.DataSource = bSource2;
            connection.Close();
        }
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            AddEmployee ae = new AddEmployee();
            ae.Show();
        }

        private void Admin_MouseMove(object sender, MouseEventArgs e)
        {
            showstock();
        }

        private void dataGridView2_MouseMove(object sender, MouseEventArgs e)
        {
            ShowData();
            ShowData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public bool line = false;
        private void Admin_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void Btn_Supprimer_Click(object sender, EventArgs e)
        {
            line = true;
            List<string> SelectedRows = new List<string>();
            for (int count = 0; count < dataGridView2.SelectedRows.Count; count++)
            {
                SelectedRows.Add(dataGridView2.SelectedRows[count].Cells[0].Value.ToString());
            }
            int index = Convert.ToInt32(SelectedRows[0]);
            // MessageBox.Show(index.ToString());
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "update merlacoffee.caissier set date_fin=CURRENT_TIMESTAMP where id='" + index + "'; ";
            MySqlDataReader readerr2 = cmd2.ExecuteReader();
            MessageBox.Show("L'employee quitter leur travail");
            connection.Close();
            ShowDateCaisse();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         }

        private void button1_Click(object sender, EventArgs e)
        {
            StockUpdate st = new StockUpdate();
            st.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap objBmp = new Bitmap(this.dataGridView4.Width, this.dataGridView4.Height);
            dataGridView4.DrawToBitmap(objBmp, new Rectangle(0,0, this.dataGridView4.Width, this.dataGridView4.Height));
            e.Graphics.DrawImage(objBmp,250,120);
            
        }
    }
}
