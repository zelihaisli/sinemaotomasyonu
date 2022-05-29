using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Data.OleDb;

namespace Sinema_Otomasyonu
{
    public partial class filmekle: Form
    {
        public filmekle()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=data/database.accdb");

        private void filmekle_Load(object sender, EventArgs e)
        {
            turBox.Items.Add("Seçiniz...");
            turBox.Items.Add("Aksiyon");
            turBox.Items.Add("Komedi");
            turBox.Items.Add("Fantezi");
            turBox.Items.Add("Korku");
            turBox.Items.Add("Aşk");
            turBox.Items.Add("Bilim Kurgu");

            turBox.SelectedIndex = 0;
        }

        private void filmSave_Click(object sender, EventArgs e)
        {
            if (filmnameTxt.Text!="" && yonetmenTxt.Text!="" && turBox.SelectedItem.ToString()!= "Seçiniz..." && timeTxt.Text!="" && yearTxt.Text!="")
            {
                try
                {
                    baglantim.Open();
                    OleDbCommand salonSave = new OleDbCommand("INSERT INTO film (filmAdi,yonetmen,filmturu,filmsuresi,yapimyili) VALUES('" + filmnameTxt.Text + "','" + yonetmenTxt.Text + "','" + turBox.SelectedItem.ToString() + "','" + timeTxt.Text + "','" + yearTxt.Text+"')", baglantim);
                    salonSave.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show(filmnameTxt.Text + " isimli film başarı ile kaydedildi !", "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception msg)
                {

                    MessageBox.Show(msg.Message, "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglantim.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen Boş Alan Bırakmayınız !", "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
