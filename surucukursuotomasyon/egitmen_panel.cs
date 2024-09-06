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
    public partial class egitmen_panel : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        public egitmen_panel()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adaygörüntüle ekle = new adaygörüntüle();
            Visible = false;
            ekle.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Egitmen set TC=@TC,AD=@AD,SOYAD=@SOYAD,TELEFON=@TELEFON,SERTIFIKA_DURUMU=@SERTIFIKA_DURUMU where TC=@TC", baglan);
            komut.Parameters.AddWithValue("@TC", textBox1.Text);
            komut.Parameters.AddWithValue("@AD", textBox2.Text);
            komut.Parameters.AddWithValue("@SOYAD", textBox3.Text);
            komut.Parameters.AddWithValue("@TELEFON", textBox4.Text);
            komut.Parameters.AddWithValue("@SERTIFIKA_DURUMU", textBox5.Text);
            komut.ExecuteNonQuery();
            baglan.Close();

            baglan.Open();
            SqlCommand komut1= new SqlCommand("update Egitmen_ikamet set TC=@TC,dogum_yeri=@dogum_yeri,dogum_yılı=@dogum_yılı,adres=@adres where TC=@TC", baglan);
            komut1.Parameters.AddWithValue("@TC", textBox1.Text);
            komut1.Parameters.AddWithValue("@dogum_yeri", textBox6.Text);
            komut1.Parameters.AddWithValue("@dogum_yılı", textBox7.Text);
            komut1.Parameters.AddWithValue("@adres", textBox8.Text);          
            komut1.ExecuteNonQuery();
            baglan.Close();

            MessageBox.Show("Eğitmen bilgileri Güncellendi");
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Egitmen where TC like '" + textBox1.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["AD"].ToString();
                textBox3.Text = read["SOYAD"].ToString();
                textBox4.Text = read["TELEFON"].ToString();             
                textBox5.Text = read["SERTIFIKA_DURUMU"].ToString();
            }
            baglan.Close();

            baglan.Open();
            SqlCommand komut1 = new SqlCommand("select* from Egitmen_ikamet where TC like '" + textBox1.Text + "'", baglan);
            SqlDataReader read1 = komut1.ExecuteReader();
            while (read1.Read())
            {
                textBox6.Text = read1["dogum_yeri"].ToString();
                textBox7.Text = read1["dogum_yılı"].ToString();
                textBox8.Text = read1["adres"].ToString();               
            }
            baglan.Close();
        }
    }
}
