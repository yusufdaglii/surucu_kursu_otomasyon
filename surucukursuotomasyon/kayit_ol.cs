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
    public partial class kayit_ol : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        bool durum;
        public kayit_ol()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tckontrol();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into Surucu_kayitt(adayno,TC,AD,SOYAD,TELEFON,KAYIT_TARİHİ,ŞİFRE) values(@adayno,@TC,@AD,@SOYAD,@TELEFON,@KAYIT_TARİHİ,@ŞİFRE)", baglan);
                komut.Parameters.AddWithValue("@adayno", textBox1.Text);
                komut.Parameters.AddWithValue("@TC", textBox2.Text);
                komut.Parameters.AddWithValue("@AD", textBox3.Text);
                komut.Parameters.AddWithValue("@SOYAD", textBox4.Text);
                komut.Parameters.AddWithValue("@TELEFON", textBox5.Text);
                komut.Parameters.AddWithValue("@KAYIT_TARİHİ", DateTime.Now.ToString()); 
                komut.Parameters.AddWithValue("@ŞİFRE", textBox6.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Müşteri Kaydı Eklendi");
            }
            else
            {
                MessageBox.Show("Boş Bıraktığınız Yerler yada Aynı TC Kullanıyorsunuz .");
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            textBox5.Text = " ";
            textBox6.Text = " ";           
        }
        private void tckontrol()
        {
            durum = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Surucu_kayitt", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["adayno"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }
    }
}
