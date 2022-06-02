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
    public partial class seansekle : Form
    {
        public seansekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=data/database.accdb");
       private void filmlist()
        {
            comboBox1.Items.Add("Seçiniz...");
            try
            {
                baglantim.Open();
                OleDbCommand sorgu = new OleDbCommand("SELECT * FROM film ", baglantim);
                OleDbDataReader kayitokuma = sorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    comboBox1.Items.Add(kayitokuma.GetValue(1).ToString());
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
            comboBox2.Items.Add("Seçiniz...");
            try
            {
                baglantim.Open();
                OleDbCommand sorgu = new OleDbCommand("SELECT * FROM salon ", baglantim);
                OleDbDataReader kayitokuma = sorgu.ExecuteReader();
                while (kayitokuma.Read())
                {
                    comboBox2.Items.Add(kayitokuma.GetValue(1).ToString());
                }
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message, "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglantim.Close();
            }
        }
        private void seansekle_Load(object sender, EventArgs e)
        {
            filmlist();
            salonlist();
        }
    }
}
