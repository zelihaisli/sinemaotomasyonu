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
    public partial class salonekle : Form
    {
        public salonekle()
        {
            InitializeComponent();
            
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=data/database.accdb");



        private void button1_Click(object sender, EventArgs e)
        {
            if (salonnameTxt.Text!="")
            {
                try
                {
                    baglantim.Open();
                    OleDbCommand salonSave = new OleDbCommand("INSERT INTO salon (salonName) VALUES('" + salonnameTxt.Text + "')", baglantim);
                    salonSave.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show(salonnameTxt.Text+" isimli salon başarı ile kaydedildi !", "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Lütfen Salon Adını Boş Bırakmayınız !", "Sinema Otomasyonu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
