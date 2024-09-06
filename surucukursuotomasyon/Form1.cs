using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace surucukursuotomasyon
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");

        private void button1_Click_1(object sender, EventArgs e)
        {
            kayit_ol ekle = new kayit_ol();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }
        private String adminkullanıcıadi = "yusuf";
        private string adminşifre = "170801";
        private void button2_Click(object sender, EventArgs e)
        {

            string kullanıcıadı = textBox1.Text;
            string şifre = textBox2.Text;
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş Bırakılan Yerleri doldurun.");
            }
            else if (kullanıcıadı == adminkullanıcıadi && şifre == adminşifre)
            {
                admin_giris ekle = new admin_giris();
                Visible = false;
                ekle.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Geçersiz !!!");
            }
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adaygirissifre ekle = new adaygirissifre();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            egitmengirissifre ekle = new egitmengirissifre();
            Visible = false;
            ekle.ShowDialog();
            this.Show();         
    
        }

    
    }
}
