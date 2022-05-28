namespace Sinema_Otomasyonu
{
    public partial class Panel : Form
    {
        public Panel()
        {
            InitializeComponent();
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
    }
}