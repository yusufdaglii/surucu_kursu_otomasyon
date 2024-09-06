using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surucukursuotomasyon
{
    public partial class admin_giris : Form
    {
        public admin_giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arackayit ekle = new arackayit();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            egitmen_kayit ekle = new egitmen_kayit();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adaygörüntüle ekle = new adaygörüntüle();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            egitmengörüntüle ekle = new egitmengörüntüle();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aracgörüntüle ekle = new aracgörüntüle();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }
    }
}
