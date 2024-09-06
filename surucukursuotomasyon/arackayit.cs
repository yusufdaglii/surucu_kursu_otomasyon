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
    
    public partial class arackayit : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=YUSUF-MONSTER\\SQLEXPRESS;Initial Catalog=SURUCUKURSU;Integrated Security=True");
        bool durum;
        public arackayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arackontrol();
            if (durum == true)
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("insert into Arac_bilgi(arac_no,marka,model,renk,hp,km,aktiflik,vites_sekli,cinsi) values(@arac_no,@marka,@model,@renk,@hp,@km,@aktiflik,@vites_sekli,@cinsi)", baglan);
                komut.Parameters.AddWithValue("@arac_no", textBox1.Text);
                komut.Parameters.AddWithValue("@marka", textBox2.Text);
                komut.Parameters.AddWithValue("@model", textBox3.Text);
                komut.Parameters.AddWithValue("@renk", textBox4.Text);
                komut.Parameters.AddWithValue("@hp", textBox5.Text);
                komut.Parameters.AddWithValue("@km",textBox6.Text );
                komut.Parameters.AddWithValue("@aktiflik", textBox7.Text);
                komut.Parameters.AddWithValue("@vites_sekli", textBox8.Text);
                komut.Parameters.AddWithValue("@cinsi", textBox9.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Araç Kaydı Eklendi");
            }
            else
            {
                MessageBox.Show("Hatalı işlem yaptınız");
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
        private void arackontrol()
        {
            durum = true;
            baglan.Open();
            SqlCommand komut = new SqlCommand("select * from Arac_bilgi", baglan);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (textBox1.Text == read["arac_no"].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            baglan.Close();
        }
    }
}
