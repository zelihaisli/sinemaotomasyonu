using System;
using System.IO;
using System.IO.Ports;
using System.Data.OleDb;

namespace Sinema_Otomasyonu
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=data/database.accdb");
        private void filmlist()
        {
            filmbox.Items.Add("Se�iniz...");
            try
            {
                baglantim.Open();
                OleDbCommand sorgu = new OleDbCommand("SELECT * FROM film ", baglantim);
                OleDbDataReader kayitokuma = sorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    filmbox.Items.Add(kayitokuma.GetValue(1).ToString());
                }
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();
            }
        }

        private void salonlist()
        {
            salonbox.Items.Add("Se�iniz...");
            try
            {
                baglantim.Open();
                OleDbCommand sorgu = new OleDbCommand("SELECT * FROM salon ", baglantim);
                OleDbDataReader kayitokuma = sorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    salonbox.Items.Add(kayitokuma.GetValue(1).ToString());
                }
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            salonekle salonekle=new salonekle();
            salonekle.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            filmekle filmekle=new filmekle();
            filmekle.Show();
        }
        int=0;
        private void Panel_Load(object sender, EventArgs e)
        {

            sayac = 1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(j * 30 + 20, i * 30 + 30);
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    sayac++;
                    this.panel1.Controls.Add(btn);
                }
                if (j = 4)
                {
                    continue;
                }
            }
            filmlist();
            salonlist();
            salonbox.SelectedIndex = 0;
            filmbox.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            seansekle seansekle=new seansekle();
            seansekle.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void filmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filmbox.SelectedItem.ToString()!="" && filmbox.SelectedItem.ToString() != "Se�iniz...")
            {
                try
                {
                    baglantim.Open();
                    OleDbCommand sorgu = new OleDbCommand("SELECT * FROM film WHERE filmAdi= '"+filmbox.SelectedItem.ToString()+"'  ", baglantim);
                    OleDbDataReader kayitokuma = sorgu.ExecuteReader();
                    while (kayitokuma.Read())
                    {
                        comboBox3.Items.Add(kayitokuma.GetValue(5).ToString());
                    }
                    comboBox3.SelectedIndex = 0;
                    baglantim.Close();
                }
                catch (Exception hatamsj)
                {
                    MessageBox.Show(hatamsj.Message, "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close();
                }
            }
        }
    }
}