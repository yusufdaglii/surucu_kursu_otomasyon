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
    public partial class egitmen_kayit : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        bool durum;
        public egitmen_kayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tckontrol();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into Egitmen(TC,AD,SOYAD,TELEFON,SERTIFIKA_DURUMU,ŞİFRE) values(@TC,@AD,@SOYAD,@TELEFON,@SERTIFIKA_DURUMU,@ŞİFRE)", baglan);
                komut.Parameters.AddWithValue("@TC", textBox1.Text);
                komut.Parameters.AddWithValue("@AD", textBox2.Text);
                komut.Parameters.AddWithValue("@SOYAD", textBox3.Text);
                komut.Parameters.AddWithValue("@TELEFON", textBox4.Text);
                komut.Parameters.AddWithValue("@SERTIFIKA_DURUMU", textBox5.Text);
                komut.Parameters.AddWithValue("@ŞİFRE", textBox6.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                baglan.Open();
                SqlCommand komut1 = new SqlCommand("insert into Egitmen_ikamet(TC,dogum_yeri,dogum_yılı,adres) values(@TC,@dogum_yeri,@dogum_yılı,@adres)", baglan);
                komut1.Parameters.AddWithValue("@TC", textBox1.Text);
                komut1.Parameters.AddWithValue("@dogum_yeri", textBox7.Text);
                komut1.Parameters.AddWithValue("@dogum_yılı", textBox8.Text);
                komut1.Parameters.AddWithValue("@adres", textBox9.Text);
                komut1.ExecuteNonQuery();
                baglan.Close();

                MessageBox.Show("Eğitmen Kaydı Eklendi");
            }
            else
            {
                MessageBox.Show("HATALI İŞLEM YAPTINIZ");
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
        }
        private void tckontrol()
        {
            durum = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Egitmen", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["TC"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }
    }
}
