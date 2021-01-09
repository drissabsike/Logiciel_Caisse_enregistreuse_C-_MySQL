using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace MerlaCoffee
{
    public partial class Home : Form
    {
        readonly MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=");
        public void UpdateCafe()
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - 1 WHERE nommat='pack_café'";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }
        public void UpdateSucre()
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - 1 WHERE nommat='buchettes_sucre'";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }
        public void UpdateDuLait()
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - 1 WHERE nommat='pack_lait_jawda'";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }
        public void UpdateCreps()
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - 1 WHERE nommat='creps'";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }
        public void UpdatePat()
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - 1 WHERE nommat='patisseries'";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }
        public void UpdateBout()
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - 1 WHERE nommat='bouteille_deau'";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }

        public Home()
        {
            InitializeComponent();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            // btAddClicked = true;
        }

        public void Clickedbuttonmoin(object sender, EventArgs e)
        {

        }
        public void Clickedbuttonplus(object sender, EventArgs e)
        {
            listBox1.Items.Add("+");

        }


        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // label19.Text = DateTime.Now.ToLongTimeString();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT nommat,qte from merlacoffee.matiere_premiere where qte = 0 ";
            try
            {
                MySqlDataReader readerr = cmd.ExecuteReader();
                while (readerr.Read())
                {
                    if (int.Parse(readerr["qte"].ToString()) == 0)
                    {
                        Label8.Text = "le produit dans le stock : " + readerr["nommat"].ToString() + " est vide !!";
                    }
                }
            }
            catch (MySqlException ms)
            {
                MessageBox.Show(ms.Message);
            }
            connection.Close();
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd.CommandText = "UPDATE merlacoffee.matiere_premiere set datefin=CURRENT_TIMESTAMP  where qte = 0 ";
            MySqlDataReader readerr2 = cmd.ExecuteReader();
            connection.Close();

        }
        public void Charge(int a)
        {
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.matiere_premiere SET qte = qte - '" + a + "' WHERE nommat='creps'; ";
            _ = cmd2.ExecuteReader();
            connection.Close();
        }
        public int Showqte(string va)
        {
            int ss = 0;
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "select  quantitec from merlacoffee.creps WHERE nomcrep='" + va + "' ";
            MySqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                ss = int.Parse(dr.GetValue(0).ToString());
            }
            connection.Close();
            return ss;
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            String va = "croissant amandes";
            Showprixp(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.patisseries SET quantite = quantite + 1 WHERE nompatisserie='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdatePat();
        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
        void Showprixp(String va)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "Select cast((prixp*(1+tvadespatisseries/100)) as decimal (18,2)) as ttc from merlacoffee.patisseries,merlacoffee.getsion_tva where nompatisserie='" + va + "' ";
            try
            {
                MySqlDataReader readerr = cmd.ExecuteReader();
                while (readerr.Read())
                {
                    listBox1.Items.Add(readerr["ttc"]).ToString();
                    listBox2.Items.Add(va);
                }
            }
            catch (MySqlException ms)
            {
                MessageBox.Show(ms.Message);
            }
            connection.Close();
        }
        private void Button10_Click(object sender, EventArgs e)
        {
            String va = "cupcake";
            Showprixp(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.patisseries SET quantite = quantite + 1 WHERE nompatisserie='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdatePat();
        }

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            String va = "pain chocolat";
            Showprixp(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.patisseries SET quantite = quantite + 1 WHERE nompatisserie='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdatePat();
        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            String va = "croissant";
            Showprixp(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.patisseries SET quantite = quantite + 1 WHERE nompatisserie='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdatePat();
        }



        private void SplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Showprixb(String va)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT cast((prixb*(1+tvadesboissons/100)) as decimal (18,2)) as ttc from merlacoffee.boissons,merlacoffee.getsion_tva where nomboisson='" + va + "' ";
            try
            {
                MySqlDataReader readerr = cmd.ExecuteReader();
                while (readerr.Read())
                {
                    //MessageBox.Show("Helloo");
                    listBox1.Items.Add(readerr["ttc"]).ToString();
                    listBox2.Items.Add(va);
                }
            }
            catch (MySqlException ms)
            {
                MessageBox.Show(ms.Message);
            }
            connection.Close();
        }
        private void Btn1_Click(object sender, EventArgs e)
        {
            String va = "allonge";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            String va = "irish";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
            UpdateDuLait();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }


        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            txtTotal.Enabled = false;
        }
        public void Addtc(String a)
        {
            connection.Open();
            MySqlCommand cmdx = connection.CreateCommand();
            cmdx.CommandText = "INSERT INTO merlacoffee.commande (datecmd,TTC) values (CURRENT_TIMESTAMP,'" + a + "');";
            _ = cmdx.ExecuteReader();
            connection.Close();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //Print
            float sum = 0;
            for (int s = 0; s < listBox1.Items.Count; s++)
            {
                sum += (float)Convert.ToDouble(listBox1.Items[s]);
            }
            textBox1.Text = sum.ToString();
            txtTotal.Text = "Prix Total : " + sum.ToString() + "€";
            Addtc(sum.ToString());
            //Print document
            String filename = "Ticket.docx";
            var doc = DocX.Create(filename);
            String title = "Welcome To MerlaCoffee ^.^";
            Formatting titleFormat = new Formatting
            {
                FontFamily = new Xceed.Document.NET.Font("Times new roman"),
                Size = 20D,
                Position = 40,
                FontColor = Color.Blue,
                UnderlineColor = Color.Brown,
                Italic = true
            };
            doc.InsertParagraph(title, false, titleFormat);
            Xceed.Document.NET.Image img = doc.AddImage(@"cap.jpg");
            Picture p = img.CreatePicture();
            Paragraph par = doc.InsertParagraph("");
            par.AppendPicture(p);
            doc.InsertParagraph("Le " + DateTime.Now.ToString() + " a Rabat");

            for (int n = 0; n < listBox2.Items.Count; n++)
            {
                doc.InsertParagraph(listBox2.Items[n].ToString());
            }

            for (int s = 0; s < listBox1.Items.Count; s++)
                {
                    doc.InsertParagraph(listBox1.Items[s].ToString() + " €");
                }
            
            doc.InsertParagraph("Prix Total : " + sum.ToString()+ "€");
            float a = sum * Convert.ToInt32(10.7);
            doc.InsertParagraph("Prix Total : " + a.ToString() + "dh");
            doc.Save();
            Process.Start("WINWORD.EXE", filename);
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            String va = "mocaccino";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
            UpdateDuLait();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "";
            listBox1.Items.Clear();
            listBox2.Items.Clear();
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            String va = "vienna";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
            UpdateDuLait();
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            String va = "cappuccino";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
            UpdateDuLait();
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            String va = "espresso macchiato";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
            UpdateDuLait();
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            String va = "espresso";
            Showprixb(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.boissons SET quantiteb = quantiteb + 1 WHERE nomboisson='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            UpdateCafe();
            UpdateSucre();
            UpdateBout();
        }

        private void ListBox1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Move(object sender, EventArgs e)
        {

        }

        private void Form1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }
        void Showprixc(String va)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            //Select cast((prixc*(1+tvadescreps/100)) as decimal (18,2)) as ttc from creps,getsion_tva where nomcrep=
            cmd.CommandText = "Select cast((prixc*(1+tvadescreps/100)) as decimal (18,2)) as ttc from merlacoffee.creps,merlacoffee.getsion_tva where nomcrep='" + va + "' ";
            try
            {
                MySqlDataReader readerr = cmd.ExecuteReader();
                while (readerr.Read())
                {
                    listBox1.Items.Add(readerr["ttc"]).ToString();
                    listBox2.Items.Add(va);
                }
            }
            catch (MySqlException ms)
            {
                MessageBox.Show(ms.Message);
            }
            connection.Close();
        }
        private void Btn12_Click(object sender, EventArgs e)
        {
            String va = "crepes fraises";
            Showprixc(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.creps SET quantitec = quantitec + 1 WHERE nomcrep='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            Showqte(va);
            UpdateCreps();
        }

        private void Btn13_Click(object sender, EventArgs e)
        {
            String va = "crepes mille trou";
            Showprixc(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.creps SET quantitec = quantitec + 1 WHERE nomcrep='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            Showqte(va);
            UpdateCreps();
        }

        private void Btn14_Click(object sender, EventArgs e)
        {
            String va = "crepes chocolat";
            Showprixc(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.creps SET quantitec = quantitec + 1 WHERE nomcrep='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            Showqte(va);
            UpdateCreps();
        }

        private void Btn15_Click(object sender, EventArgs e)
        {
            String va = "crepes bananes";
            Showprixc(va);
            connection.Open();
            MySqlCommand cmd2 = connection.CreateCommand();
            cmd2.CommandText = "UPDATE merlacoffee.creps SET quantitec = quantitec + 1 WHERE nomcrep='" + va + "' ";
            _ = cmd2.ExecuteReader();
            connection.Close();
            int a = Showqte(va);
            Charge(a);
            UpdateCreps();
        }

        private void Btnzero_Click(object sender, EventArgs e)
        {
            int a = 0;
            listBox1.Items.Add(a);
        }

        private void Btnun_Click(object sender, EventArgs e)
        {
            int a = 1;
            listBox1.Items.Add(a);
        }

        private void Btndeux_Click(object sender, EventArgs e)
        {
            int a = 2;
            listBox1.Items.Add(a);
        }

        private void Btntrois_Click(object sender, EventArgs e)
        {
            int nb = 3;
            listBox1.Items.Add(nb);
        }

        private void Btnquatre_Click(object sender, EventArgs e)
        {
            int nb = 4;
            listBox1.Items.Add(nb);
        }

        private void Btncinq_Click(object sender, EventArgs e)
        {
            int nb = 5;
            listBox1.Items.Add(nb);
        }

        private void Btnsix_Click(object sender, EventArgs e)
        {

            int nb = 6;
            listBox1.Items.Add(nb);
        }

        private void Btnsept_Click(object sender, EventArgs e)
        {

            int nb = 7;
            listBox1.Items.Add(nb);
        }

        private void Btnhuit_Click(object sender, EventArgs e)
        {

            int nb = 8;
            listBox1.Items.Add(nb);
        }

        private void Btnneuf_Click(object sender, EventArgs e)
        {

            int nb = 9;
            listBox1.Items.Add(nb);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            float sum = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sum += (float)Convert.ToDouble(listBox1.Items[i]);
            }
            float a = sum * Convert.ToInt32(10.7);
            txtTotal.Text = "Prix Total :" + a.ToString() + "DH";
        }

        private void Btndular_Click(object sender, EventArgs e)
        {
            float sum = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sum += (float)Convert.ToDouble(listBox1.Items[i]);
            }

            _ = sum * Convert.ToInt32(1.1);
            txtTotal.Text = "Prix Total : " + sum.ToString() + "$";
        }

        public float Summe()
        {
            float sum = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sum += (float)Convert.ToDouble(listBox1.Items[i]);
            }
            return sum;
        }
        public float Ret()
        {
            float s = 0;
            if (listBox1.Items.Count > 0)
            {
                s = float.Parse(listBox1.Items[listBox1.Items.Count - 1].ToString());
            }
            return s;
        }

        private void Btnmoin_Click(object sender, EventArgs e)
        {
            try
            {
                float a = float.Parse(textBox1.Text) - Ret();
                txtTotal.Text = "Prix Total : " + a.ToString() + "€";
            }
            catch (Exception ss)
            {
                MessageBox.Show(ss.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //Gestion Stock
            Gestion_Stock gs = new Gestion_Stock();
            gs.Show();
        }

        private void Btnplus_Click(object sender, EventArgs e)
        {

        }

        private void Btn_quiter_Click(object sender, EventArgs e)
        {
            String cin = StartWork.CIN;
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE merlacoffee.duree_de_travail SET date_f=CURRENT_TIMESTAMP WHERE id=id = (SELECT id from merlacoffee.caissier where CIN='" + cin + "')";
            _ = cmd.ExecuteReader();
            MessageBox.Show("Monsieur " + cin + " au revoire a demain !");
            this.Close();
            connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label19.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }
    }
}
