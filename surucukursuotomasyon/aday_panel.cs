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
    public partial class aday_panel : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        public aday_panel()
        {
            InitializeComponent();
        }
        bool durum;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Surucu_kayitt where adayno like '" + textBox1.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox2.Text = read["TC"].ToString();
                textBox3.Text = read["AD"].ToString();
                textBox4.Text = read["SOYAD"].ToString();
                textBox5.Text = read["TELEFON"].ToString();

            }
            baglan.Close();
        }
        //*******************************************************************************************************
        private void saglık_btn_Click(object sender, EventArgs e)
        {
            saglikontrol();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into Aday_saglik (adayno,kan_grubu,kalıtsal_hastalık,engel_durumu) values(@adayno,@kan_grubu,@kalıtsal_hastalık,@engel_durumu)", baglan);
                komut.Parameters.AddWithValue("@adayno", textBox6.Text);
                komut.Parameters.AddWithValue("@kan_grubu", textBox7.Text);
                komut.Parameters.AddWithValue("@kalıtsal_hastalık", textBox8.Text);
                komut.Parameters.AddWithValue("@engel_durumu", textBox9.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Sağlık bilgileri eklendi");
            }
            else
            {
                MessageBox.Show("HATALI İŞLEM YAPTINIZ");
            }

            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";        

        }
        private void saglikontrol()
        {
            durum = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Aday_saglik", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox6.Text == read["adayno"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        { 
            if (textBox6.Text == "")
            {
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";            
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Aday_saglik where adayno like '" + textBox6.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox7.Text = read["kan_grubu"].ToString();
                textBox8.Text = read["kalıtsal_hastalık"].ToString();
                textBox9.Text = read["engel_durumu"].ToString();
            }
            baglan.Close();
        }    
        
        private void saglik_guncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Aday_saglik set kan_grubu=@kan_grubu,kalıtsal_hastalık=@kalıtsal_hastalık,engel_durumu=@engel_durumu where adayno=@adayno", baglan);
            komut.Parameters.AddWithValue("@adayno", textBox6.Text);
            komut.Parameters.AddWithValue("@kan_grubu", textBox7.Text);
            komut.Parameters.AddWithValue("@kalıtsal_hastalık", textBox8.Text);
            komut.Parameters.AddWithValue("@engel_durumu", textBox9.Text);        
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Sağlık bilgileri Güncellendi");
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
            textBox9.Text = " ";
        }
        //*************************************************************************************************************
        private void odeme_btn_Click(object sender, EventArgs e)
        {
            odemekontrol();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into Aday_odeme (adayno,odeme_miktar,odeme_sekli,borc_durumu) values(@adayno,@odeme_miktar,@odeme_sekli,@borc_durumu)", baglan);
                komut.Parameters.AddWithValue("@adayno", textBox16.Text);
                komut.Parameters.AddWithValue("@odeme_miktar", textBox17.Text);
                komut.Parameters.AddWithValue("@odeme_sekli", textBox18.Text);
                komut.Parameters.AddWithValue("@borc_durumu", textBox19.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Ödeme bilgileri eklendi");
            }
            else
            {
                MessageBox.Show("HATALI İŞLEM YAPTINIZ");
            }

            textBox16.Text = " ";
            textBox17.Text = " ";
            textBox18.Text = " ";
            textBox19.Text = " ";
        }
        private void odemekontrol()
        {
            durum = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Aday_odeme", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox16.Text == read["adayno"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            if (textBox16.Text == "")
            {
                textBox17.Text = "";
                textBox18.Text = "";
                textBox19.Text = "";
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Aday_odeme where adayno like '" + textBox16.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox17.Text = read["odeme_miktar"].ToString();
                textBox18.Text = read["odeme_sekli"].ToString();
                textBox19.Text = read["borc_durumu"].ToString();
            }
            baglan.Close();
        }

        private void odeme_guncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Aday_odeme set odeme_miktar=@odeme_miktar,odeme_sekli=@odeme_sekli,borc_durumu=@borc_durumu where adayno=@adayno", baglan);
            komut.Parameters.AddWithValue("@adayno", textBox16.Text);
            komut.Parameters.AddWithValue("@odeme_miktar", textBox17.Text);
            komut.Parameters.AddWithValue("@odeme_sekli", textBox18.Text);
            komut.Parameters.AddWithValue("@borc_durumu", textBox19.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Ödeme bilgileri Güncellendi");
            textBox16.Text = " ";
            textBox17.Text = " ";
            textBox18.Text = " ";
            textBox19.Text = " ";
        }
        //*************************************************************************************************************
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            if (textBox11.Text == "")
            {
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
            }
            baglan.Open();
            SqlCommand komut = new SqlCommand("select* from Aday_ikamet where adayno like '" + textBox11.Text + "'", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                textBox12.Text = read["dogum_yeri"].ToString();
                textBox13.Text = read["dogum_yılı"].ToString();
                textBox14.Text = read["adres"].ToString();
            }
            baglan.Close();
        }

        private void ikamet_btn_Click(object sender, EventArgs e)
        {
            ikametkontrol();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into Aday_ikamet (adayno,dogum_yeri,dogum_yılı,adres) values(@adayno,@dogum_yeri,@dogum_yılı,@adres)", baglan);
                komut.Parameters.AddWithValue("@adayno", textBox11.Text);
                komut.Parameters.AddWithValue("@dogum_yeri", textBox12.Text);
                komut.Parameters.AddWithValue("@dogum_yılı", textBox13.Text);
                komut.Parameters.AddWithValue("@adres", textBox14.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("İkamet bilgileri eklendi");
            }
            else
            {
                MessageBox.Show("HATALI İŞLEM YAPTINIZ");
            }

            textBox11.Text = " ";
            textBox12.Text = " ";
            textBox13.Text = " ";
            textBox14.Text = " ";
        }
        private void ikametkontrol()
        {
            durum = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Aday_ikamet", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox11.Text == read["adayno"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }

        private void ikamet_guncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update Aday_ikamet set  dogum_yeri=@dogum_yeri,dogum_yılı=@dogum_yılı,adres=@adres where adayno=@adayno", baglan);
            komut.Parameters.AddWithValue("@adayno", textBox11.Text);
            komut.Parameters.AddWithValue("@dogum_yeri", textBox12.Text);
            komut.Parameters.AddWithValue("@dogum_yılı", textBox13.Text);
            komut.Parameters.AddWithValue("@adres", textBox14.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("İkamet bilgileri Güncellendi");
            textBox11.Text = " ";
            textBox12.Text = " ";
            textBox13.Text = " ";
            textBox14.Text = " ";
        }

        
    }
}
